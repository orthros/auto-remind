using aurm.core.notifications;
using aurm.core.tasks;
using aurm.notifier;
using aurm.tasker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aurm.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public INotifier Notifier { get; private set; }
        public ITaskMonitor TaskMonitor { get; private set; }

        private System.Windows.Forms.NotifyIcon notificationIcon { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.SetupNotificationIcon();

            Notifier = new TwilioNotifier();
            
            TaskMonitor = new Tasker();
            TaskMonitor.TaskUpdated += tasker_TaskUpdated;

            var tasksToMonior = GetTasks();
            TaskMonitor.StartMonitoring(tasksToMonior);
        }

        private void tasker_TaskUpdated(TaskUpdatedEventArgs e)
        {
            //Need to prompt the user then notify

            this.Notifier.Notify(e.RaisedTask.Recipient, e.RaisedTask.Message);
        }

        private List<AurmTask> GetTasks()
        {
            List<AurmTask> returnTaskList = new List<AurmTask>();

            var directoryPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "aurm");
            DirectoryInfo di = new DirectoryInfo(directoryPath);
            if (!di.Exists) { di.Create(); }

            #region For Debugging, add a sample task
            if(!(di.GetFiles("*.json").Count() > 0))
            {
                var addT = new AurmTask(Guid.NewGuid(), new SMSRecipient("MySelf", "1234567890"),
                    "Hey this is a test!", 
                    new TimeCondition(new HashSet<DayOfWeek>() { DayOfWeek.Thursday }, 14, 27),
                    new List<ICondition>());

                using (var sw = File.OpenWrite(System.IO.Path.Combine(di.FullName, "sample.json")))
                {
                    using (var tw = new StreamWriter(sw))
                    {
                        using (var jtw = new JsonTextWriter(tw))
                        {
                            var jser = new JsonSerializer();
                            jser.TypeNameHandling = TypeNameHandling.All;

                            jser.Serialize(jtw, addT);
                        }
                    }
                }
            }
            #endregion

            foreach (var nestedFile in di.GetFiles("*.json"))
            {
                //Read the file and grab the data from it
                using (StreamReader fileStrReader = File.OpenText(nestedFile.FullName))
                {
                    using (JsonTextReader jsonReader = new JsonTextReader(fileStrReader))
                    {
                        JsonSerializer jsonSer = new JsonSerializer();
                        jsonSer.TypeNameHandling = TypeNameHandling.All;
                              
                        var newTask = jsonSer.Deserialize<AurmTask>(jsonReader);
                        returnTaskList.Add(newTask);
                    }
                }
            }
            
            return returnTaskList;
        }

        #region System.Windows.Forms Hack to get a notification icon in the tray
        private void SetupNotificationIcon()
        {
            notificationIcon = new System.Windows.Forms.NotifyIcon();
            notificationIcon.Icon = new System.Drawing.Icon(System.IO.Path.Combine("Images", "notification.ico"));
            notificationIcon.Visible = true;

            var mi = new System.Windows.Forms.MenuItem("Exit");
            mi.Click += exitMenuItem_Click;

            System.Windows.Forms.MenuItem[] items = new System.Windows.Forms.MenuItem[1];
            items[0] = mi;

            notificationIcon.ContextMenu = new System.Windows.Forms.ContextMenu(items);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            notificationIcon.Dispose();
            this.Close();
        }
        #endregion
    }
}
