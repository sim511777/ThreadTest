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

      private void TestFunc(object obj) {
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
      
      private void Form1_Load(object sender, EventArgs e) {
         this.lbxTest.Items.AddRange(this.testItems);
      }

      private void btnClear_Click(object sender, EventArgs e) {
         this.lbxLog.Items.Clear();
      }

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
         }
      }

      private string[] testItems = {
         "Non Thread",
         "Thread",
         "Thread Pool",
         "Async Delegate",
      };

      private void NonThreadTest() {
         this.TestFunc(Tuple.Create("Non Thread 1", 20));
         this.TestFunc(Tuple.Create("Non Thread 2", 20));
      }

      private void ThreadTest() {
         Thread thread1 = new Thread(() => this.TestFunc(Tuple.Create("Normal Thread 1", 20)));
         Thread thread2 = new Thread(() => this.TestFunc(Tuple.Create("Normal Thread 2", 20)));
         thread1.Start();
         thread2.Start();
      }

      private void ThreadPoolTest() {
         ThreadPool.QueueUserWorkItem(this.TestFunc, Tuple.Create("Thread Pool 1", 20));
         ThreadPool.QueueUserWorkItem(this.TestFunc, Tuple.Create("Thread Pool 2", 20));
      }

      private void AsyncDelegateTest() {
         Action<Tuple<string, int>> action = TestFunc;
         var r1 = action.BeginInvoke(Tuple.Create("Async Delegate 1", 20), null, null);
         var r2 = action.BeginInvoke(Tuple.Create("Async Delegate 2", 20), null, null);
         //var r3 = action.BeginInvoke(Tuple.Create("Async Delegate 3", 20), null, null);
         //action.EndInvoke(r1);
         //action.EndInvoke(r2);
         //action.EndInvoke(r3);
      }
   }
}
