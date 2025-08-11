<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class makeinstaller
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(makeinstaller))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.list = New System.Windows.Forms.Label()
        Me.list2 = New System.Windows.Forms.Label()
        Me.list3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 148)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(395, 38)
        Me.ProgressBar1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Operazioni"
        '
        'list
        '
        Me.list.AutoSize = True
        Me.list.Location = New System.Drawing.Point(12, 55)
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(146, 16)
        Me.list.TabIndex = 2
        Me.list.Text = "- Scarico INSTALLER..."
        '
        'list2
        '
        Me.list2.AutoSize = True
        Me.list2.Location = New System.Drawing.Point(12, 80)
        Me.list2.Name = "list2"
        Me.list2.Size = New System.Drawing.Size(213, 16)
        Me.list2.TabIndex = 3
        Me.list2.Text = "- Scarico la cartella Fondamental..."
        '
        'list3
        '
        Me.list3.AutoSize = True
        Me.list3.Location = New System.Drawing.Point(12, 105)
        Me.list3.Name = "list3"
        Me.list3.Size = New System.Drawing.Size(222, 16)
        Me.list3.TabIndex = 4
        Me.list3.Text = "- Estraggo la cartella Fondamental..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.INSTALLERtools.My.Resources.Resources.Igh0zt_Ios7_Style_Metro_Ui_MetroUI_Apps_Mac_App_Store
        Me.PictureBox1.Location = New System.Drawing.Point(272, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 109)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'makeinstaller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 186)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.list3)
        Me.Controls.Add(Me.list2)
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "makeinstaller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents list As Label
    Friend WithEvents list2 As Label
    Friend WithEvents list3 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
