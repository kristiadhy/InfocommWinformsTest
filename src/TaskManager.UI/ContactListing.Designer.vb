<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContactListing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grdContacts = New System.Windows.Forms.DataGridView()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.ButtonEdit = New System.Windows.Forms.Button()
        Me.btnImportContact = New System.Windows.Forms.Button()
        Me.txtByName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtByEmail = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.rdByEmail = New System.Windows.Forms.RadioButton()
        Me.rdByName = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLoadAll = New System.Windows.Forms.Button()
        CType(Me.grdContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdContacts
        '
        Me.grdContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdContacts.Location = New System.Drawing.Point(13, 172)
        Me.grdContacts.Margin = New System.Windows.Forms.Padding(4)
        Me.grdContacts.Name = "grdContacts"
        Me.grdContacts.RowHeadersWidth = 51
        Me.grdContacts.Size = New System.Drawing.Size(597, 376)
        Me.grdContacts.TabIndex = 0
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Location = New System.Drawing.Point(14, 572)
        Me.ButtonAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(100, 28)
        Me.ButtonAdd.TabIndex = 1
        Me.ButtonAdd.Text = "Add Contact"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(257, 11)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(84, 20)
        Me.lblHeader.TabIndex = 2
        Me.lblHeader.Text = "Contacts"
        '
        'ButtonEdit
        '
        Me.ButtonEdit.Location = New System.Drawing.Point(122, 572)
        Me.ButtonEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.Size = New System.Drawing.Size(100, 28)
        Me.ButtonEdit.TabIndex = 3
        Me.ButtonEdit.Text = "Edit Contact"
        Me.ButtonEdit.UseVisualStyleBackColor = True
        '
        'btnImportContact
        '
        Me.btnImportContact.Location = New System.Drawing.Point(510, 572)
        Me.btnImportContact.Margin = New System.Windows.Forms.Padding(4)
        Me.btnImportContact.Name = "btnImportContact"
        Me.btnImportContact.Size = New System.Drawing.Size(100, 28)
        Me.btnImportContact.TabIndex = 4
        Me.btnImportContact.Text = "Import Contact"
        Me.btnImportContact.UseVisualStyleBackColor = True
        '
        'txtByName
        '
        Me.txtByName.Location = New System.Drawing.Point(35, 48)
        Me.txtByName.Name = "txtByName"
        Me.txtByName.Size = New System.Drawing.Size(191, 22)
        Me.txtByName.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Email"
        '
        'txtByEmail
        '
        Me.txtByEmail.Location = New System.Drawing.Point(274, 48)
        Me.txtByEmail.Name = "txtByEmail"
        Me.txtByEmail.Size = New System.Drawing.Size(191, 22)
        Me.txtByEmail.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(489, 45)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 28)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'rdByEmail
        '
        Me.rdByEmail.AutoSize = True
        Me.rdByEmail.Location = New System.Drawing.Point(248, 29)
        Me.rdByEmail.Name = "rdByEmail"
        Me.rdByEmail.Size = New System.Drawing.Size(17, 16)
        Me.rdByEmail.TabIndex = 10
        Me.rdByEmail.TabStop = True
        Me.rdByEmail.UseVisualStyleBackColor = True
        '
        'rdByName
        '
        Me.rdByName.AutoSize = True
        Me.rdByName.Location = New System.Drawing.Point(11, 29)
        Me.rdByName.Name = "rdByName"
        Me.rdByName.Size = New System.Drawing.Size(17, 16)
        Me.rdByName.TabIndex = 11
        Me.rdByName.TabStop = True
        Me.rdByName.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtByName)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.rdByEmail)
        Me.GroupBox1.Controls.Add(Me.rdByName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtByEmail)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(596, 94)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By"
        '
        'btnLoadAll
        '
        Me.btnLoadAll.Location = New System.Drawing.Point(14, 136)
        Me.btnLoadAll.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoadAll.Name = "btnLoadAll"
        Me.btnLoadAll.Size = New System.Drawing.Size(155, 28)
        Me.btnLoadAll.TabIndex = 13
        Me.btnLoadAll.Text = "Load All Data"
        Me.btnLoadAll.UseVisualStyleBackColor = True
        '
        'ContactListing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 615)
        Me.Controls.Add(Me.btnLoadAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnImportContact)
        Me.Controls.Add(Me.ButtonEdit)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.ButtonAdd)
        Me.Controls.Add(Me.grdContacts)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ContactListing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contact Listing"
        CType(Me.grdContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdContacts As DataGridView
    Friend WithEvents ButtonAdd As Button
    Friend WithEvents lblHeader As Label
    Friend WithEvents ButtonEdit As Button
    Friend WithEvents btnImportContact As Button
    Friend WithEvents txtByName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtByEmail As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents rdByEmail As RadioButton
    Friend WithEvents rdByName As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLoadAll As Button
End Class
