namespace ThreadTest {
   partial class Form1 {
      /// <summary>
      /// 필수 디자이너 변수입니다.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// 사용 중인 모든 리소스를 정리합니다.
      /// </summary>
      /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form 디자이너에서 생성한 코드

      /// <summary>
      /// 디자이너 지원에 필요한 메서드입니다. 
      /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
      /// </summary>
      private void InitializeComponent() {
         this.panel1 = new System.Windows.Forms.Panel();
         this.lbxTest = new System.Windows.Forms.ListBox();
         this.btnClear = new System.Windows.Forms.Button();
         this.lbxLog = new System.Windows.Forms.ListBox();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.lbxTest);
         this.panel1.Controls.Add(this.btnClear);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(146, 451);
         this.panel1.TabIndex = 0;
         // 
         // lbxTest
         // 
         this.lbxTest.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lbxTest.FormattingEnabled = true;
         this.lbxTest.ItemHeight = 12;
         this.lbxTest.Location = new System.Drawing.Point(0, 0);
         this.lbxTest.Name = "lbxTest";
         this.lbxTest.Size = new System.Drawing.Size(146, 428);
         this.lbxTest.TabIndex = 3;
         this.lbxTest.DoubleClick += new System.EventHandler(this.lbxTest_DoubleClick);
         // 
         // btnClear
         // 
         this.btnClear.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.btnClear.Location = new System.Drawing.Point(0, 428);
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(146, 23);
         this.btnClear.TabIndex = 2;
         this.btnClear.Text = "Clear";
         this.btnClear.UseVisualStyleBackColor = true;
         this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
         // 
         // lbxLog
         // 
         this.lbxLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lbxLog.FormattingEnabled = true;
         this.lbxLog.ItemHeight = 12;
         this.lbxLog.Location = new System.Drawing.Point(146, 0);
         this.lbxLog.Name = "lbxLog";
         this.lbxLog.Size = new System.Drawing.Size(431, 451);
         this.lbxLog.TabIndex = 2;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(577, 451);
         this.Controls.Add(this.lbxLog);
         this.Controls.Add(this.panel1);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.ListBox lbxLog;
      private System.Windows.Forms.Button btnClear;
      private System.Windows.Forms.ListBox lbxTest;
   }
}

