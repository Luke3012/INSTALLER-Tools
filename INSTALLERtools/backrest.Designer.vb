<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class backrest
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(backrest))
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stato = New System.Windows.Forms.Label()
        Me.list1 = New System.Windows.Forms.Label()
        Me.list2 = New System.Windows.Forms.Label()
        Me.list3 = New System.Windows.Forms.Label()
        Me.list4 = New System.Windows.Forms.Label()
        Me.list5 = New System.Windows.Forms.Label()
        Me.list6 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.totale = New System.Windows.Forms.Label()
        Me.copystat = New System.Windows.Forms.Label()
        Me.list7 = New System.Windows.Forms.Label()
        Me.annullo = New System.Windows.Forms.Button()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.copygb = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.numerror = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dimfile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nomefile = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer3
        '
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 375)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 73)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "..."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'stato
        '
        Me.stato.AutoSize = True
        Me.stato.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stato.Location = New System.Drawing.Point(13, 384)
        Me.stato.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.stato.Name = "stato"
        Me.stato.Size = New System.Drawing.Size(264, 25)
        Me.stato.TabIndex = 1
        Me.stato.Text = "Avanzamento Totale : 0 %"
        '
        'list1
        '
        Me.list1.AutoSize = True
        Me.list1.Location = New System.Drawing.Point(53, 20)
        Me.list1.Name = "list1"
        Me.list1.Size = New System.Drawing.Size(122, 16)
        Me.list1.TabIndex = 2
        Me.list1.Text = "Desktop - Attendi ..."
        '
        'list2
        '
        Me.list2.AutoSize = True
        Me.list2.Location = New System.Drawing.Point(53, 45)
        Me.list2.Name = "list2"
        Me.list2.Size = New System.Drawing.Size(135, 16)
        Me.list2.TabIndex = 3
        Me.list2.Text = "Documenti - Attendi ..."
        '
        'list3
        '
        Me.list3.AutoSize = True
        Me.list3.Location = New System.Drawing.Point(53, 70)
        Me.list3.Name = "list3"
        Me.list3.Size = New System.Drawing.Size(132, 16)
        Me.list3.TabIndex = 4
        Me.list3.Text = "Download - Attendi ..."
        '
        'list4
        '
        Me.list4.AutoSize = True
        Me.list4.Location = New System.Drawing.Point(53, 96)
        Me.list4.Name = "list4"
        Me.list4.Size = New System.Drawing.Size(125, 16)
        Me.list4.TabIndex = 5
        Me.list4.Text = "Immagini - Attendi ..."
        '
        'list5
        '
        Me.list5.AutoSize = True
        Me.list5.Location = New System.Drawing.Point(53, 121)
        Me.list5.Name = "list5"
        Me.list5.Size = New System.Drawing.Size(114, 16)
        Me.list5.TabIndex = 6
        Me.list5.Text = "Musica - Attendi ..."
        '
        'list6
        '
        Me.list6.AutoSize = True
        Me.list6.Location = New System.Drawing.Point(53, 146)
        Me.list6.Name = "list6"
        Me.list6.Size = New System.Drawing.Size(107, 16)
        Me.list6.TabIndex = 7
        Me.list6.Text = "Video - Attendi ..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 225)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(438, 42)
        Me.ProgressBar1.TabIndex = 8
        '
        'totale
        '
        Me.totale.AutoSize = True
        Me.totale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totale.Location = New System.Drawing.Point(15, 343)
        Me.totale.Name = "totale"
        Me.totale.Size = New System.Drawing.Size(240, 18)
        Me.totale.TabIndex = 9
        Me.totale.Text = "Dimensione Totale: Calcolo in Corso ..."
        '
        'copystat
        '
        Me.copystat.AutoSize = True
        Me.copystat.Location = New System.Drawing.Point(12, 206)
        Me.copystat.Name = "copystat"
        Me.copystat.Size = New System.Drawing.Size(204, 16)
        Me.copystat.TabIndex = 10
        Me.copystat.Text = "Copio File 0 di Calcolo in corso ..."
        '
        'list7
        '
        Me.list7.AutoSize = True
        Me.list7.Location = New System.Drawing.Point(53, 171)
        Me.list7.Name = "list7"
        Me.list7.Size = New System.Drawing.Size(116, 16)
        Me.list7.TabIndex = 11
        Me.list7.Text = "Preferiti - Attendi ..."
        '
        'annullo
        '
        Me.annullo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.annullo.Enabled = False
        Me.annullo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.annullo.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.annullo.Location = New System.Drawing.Point(314, 394)
        Me.annullo.Name = "annullo"
        Me.annullo.Size = New System.Drawing.Size(136, 52)
        Me.annullo.TabIndex = 12
        Me.annullo.Text = "Annulla"
        Me.annullo.UseVisualStyleBackColor = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(15, 298)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(438, 42)
        Me.ProgressBar2.TabIndex = 13
        '
        'copygb
        '
        Me.copygb.AutoSize = True
        Me.copygb.Location = New System.Drawing.Point(12, 279)
        Me.copygb.Name = "copygb"
        Me.copygb.Size = New System.Drawing.Size(299, 16)
        Me.copygb.TabIndex = 14
        Me.copygb.Text = "Grandezza Totale File Copiati: Calcolo in corso ..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(391, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Parziale"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(401, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 18)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Totale"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.list6)
        Me.GroupBox1.Controls.Add(Me.list1)
        Me.GroupBox1.Controls.Add(Me.list2)
        Me.GroupBox1.Controls.Add(Me.list3)
        Me.GroupBox1.Controls.Add(Me.list4)
        Me.GroupBox1.Controls.Add(Me.list5)
        Me.GroupBox1.Controls.Add(Me.list7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 200)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Percorsi"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.numerror)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dimfile)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.nomefile)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(257, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(193, 200)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File"
        '
        'numerror
        '
        Me.numerror.AutoSize = True
        Me.numerror.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numerror.Location = New System.Drawing.Point(83, 171)
        Me.numerror.Name = "numerror"
        Me.numerror.Size = New System.Drawing.Size(17, 18)
        Me.numerror.TabIndex = 5
        Me.numerror.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Errori:"
        '
        'dimfile
        '
        Me.dimfile.Enabled = False
        Me.dimfile.Location = New System.Drawing.Point(10, 121)
        Me.dimfile.Name = "dimfile"
        Me.dimfile.ReadOnly = True
        Me.dimfile.Size = New System.Drawing.Size(177, 22)
        Me.dimfile.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Dimensioni File"
        '
        'nomefile
        '
        Me.nomefile.Enabled = False
        Me.nomefile.Location = New System.Drawing.Point(10, 45)
        Me.nomefile.Multiline = True
        Me.nomefile.Name = "nomefile"
        Me.nomefile.ReadOnly = True
        Me.nomefile.Size = New System.Drawing.Size(177, 47)
        Me.nomefile.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nome File"
        '
        'backrest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 458)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.copygb)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.annullo)
        Me.Controls.Add(Me.copystat)
        Me.Controls.Add(Me.totale)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.stato)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "backrest"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup o Ripristino in corso ..."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer3 As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents stato As Label
    Friend WithEvents list1 As Label
    Friend WithEvents list2 As Label
    Friend WithEvents list3 As Label
    Friend WithEvents list4 As Label
    Friend WithEvents list5 As Label
    Friend WithEvents list6 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents totale As Label
    Friend WithEvents copystat As Label
    Friend WithEvents list7 As Label
    Friend WithEvents annullo As Button
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents copygb As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents numerror As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dimfile As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents nomefile As TextBox
    Friend WithEvents Label4 As Label
End Class
