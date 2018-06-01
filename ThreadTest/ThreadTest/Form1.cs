using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ThreadTest {
   public partial class Form1 : Form {
      public Form1() {
         InitializeComponent();
      }

      private void Log(string text) {
         Action action = () => {
            this.lbxLog.TopIndex = this.lbxLog.Items.Count-1;
            this.lbxLog.Items.Add(text);
         };
         if (this.lbxLog.InvokeRequired) {
            this.lbxLog.BeginInvoke(action);
         } else {
            action();
         }
      }

      private void TestAction(object obj) {
         Tuple<string, int> param = obj as Tuple<string, int>;
         string name = param.Item1;
         int num = param.Item2;
         Log(name + " Started : ");
         for (int i=0; i<num; i++) {
            Log(name + " Run: " + i.ToString());
            Thread.Sleep(100);
         }
         Log(name + " Finished : ");
      }

      private string TestFunc(object obj) {
         Tuple<string, int> param = obj as Tuple<string, int>;
         string name = param.Item1;
         int num = param.Item2;
         Log(name + " Started : ");
         for (int i = 0; i < num; i++) {
            if (cancelTokenSource.Token.IsCancellationRequested) {
               return "Canceled";
            }
            Log(name + " Run: " + i.ToString());
            Thread.Sleep(100);
         }
         Log(name + " Finished : ");

         return param.Item1;
      }

      private void Form1_Load(object sender, EventArgs e) {
         this.lbxTest.Items.AddRange(this.testItems);
      }

      private void btnClear_Click(object sender, EventArgs e) {
         this.lbxLog.Items.Clear();
      }

      private string[] testItems = {
         "Non Thread",
         "Thread",
         "ThreadPool",
         "Async Delegate",
         "BackGroundWorker",
         "Task",
         "Task of T",
         "Task of T Cancel",
      };

      private void lbxTest_DoubleClick(object sender, EventArgs e) {
         string testItem = this.lbxTest.Text;
         if (testItem == this.testItems[0]) {
            this.NonThreadTest();
         } else if (testItem == this.testItems[1]) {
            this.ThreadTest();
         } else if (testItem == this.testItems[2]) {
            this.ThreadPoolTest();
         } else if (testItem == this.testItems[3]) {
            this.AsyncDelegateTest();
         } else if (testItem == this.testItems[4]) {
            this.BackgroundWorkerTest();
         } else if (testItem == this.testItems[5]) {
            this.TaskTest();
         } else if (testItem == this.testItems[6]) {
            this.TaskOfTTest();
         } else if (testItem == this.testItems[7]) {
            this.TaskOfTTestCancel();
         }
      }

      private void NonThreadTest() {
         this.TestAction(Tuple.Create("Non Thread 1", 20));
         this.TestAction(Tuple.Create("Non Thread 2", 20));
      }

      private void ThreadTest() {
         Thread thread1 = new Thread(() => this.TestAction(Tuple.Create("Thread 1", 20)));
         Thread thread2 = new Thread(() => this.TestAction(Tuple.Create("Thread 2", 20)));
         thread1.Start();
         thread2.Start();
      }

      private void ThreadPoolTest() {
         ThreadPool.QueueUserWorkItem(this.TestAction, Tuple.Create("ThreadPool 1", 20));
         ThreadPool.QueueUserWorkItem(this.TestAction, Tuple.Create("ThreadPool 2", 20));
      }

      private void AsyncDelegateTest() {
         Action<Tuple<string, int>> action = TestAction;
         var r1 = action.BeginInvoke(Tuple.Create("Async Delegate 1", 20), null, null);
         var r2 = action.BeginInvoke(Tuple.Create("Async Delegate 2", 20), null, null);
         //var r3 = action.BeginInvoke(Tuple.Create("Async Delegate 3", 20), null, null);
         //action.EndInvoke(r1);
         //action.EndInvoke(r2);
         //action.EndInvoke(r3);
      }

      private void BackgroundWorkerTest() {
         BackgroundWorker worker = new BackgroundWorker();
         worker.DoWork += (sender, e) => {
            this.TestAction(Tuple.Create("BackgroundWorker 1", 20));
         };
         worker.RunWorkerAsync();
      }

      private void TaskTest() {
         Task t1 = Task.Factory.StartNew(() => this.TestAction(Tuple.Create("Task 1", 20)));
         Task t2 = Task.Factory.StartNew(() => this.TestAction(Tuple.Create("Task 2", 20)));
         //t1.Wait();
         //t2.Wait();
      }

      private void TaskOfTTest() {
         Task<string> t1 = Task.Factory.StartNew<string>(() => this.TestFunc(Tuple.Create("Task Of T 1", 40)));
      }

      private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
      private CancellationToken cancelToken = cancelTokenSource.Token;
      private void TaskOfTTestCancel() {
         cancelTokenSource.Cancel();
      }
   }
}
