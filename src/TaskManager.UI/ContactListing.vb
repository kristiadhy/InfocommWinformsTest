Imports TaskManager.Core
Imports TaskManager.Data

Public Class ContactListing
    Private contacts As New List(Of Contact)()

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLiteHelper.SetupConnection()
        rdByName.Checked = True
        GetContacts()
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Using addContactForm As New AddContact()
            If addContactForm.ShowDialog() = DialogResult.OK Then
                GetContacts()
            End If
        End Using
    End Sub

    Private Sub GetContacts()
        Using contactRepo As New ContactRepository()
            contacts = contactRepo.GetContacts()
            BindContactsToDataGrid()
        End Using
    End Sub

    Private Sub BindContactsToDataGrid()
        grdContacts.DataSource = contacts
        grdContacts.Columns(NameOf(Contact.Id)).Visible = False
        grdContacts.Columns(NameOf(Contact.ActiveStatusByNumber)).Visible = False
        grdContacts.AutoResizeColumns()
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        ' Get the selected contact
        Dim selectedContact As Contact = contacts(grdContacts.CurrentCell.RowIndex)
        Using updateContactForm As New AddContact(selectedContact.Id)
            If updateContactForm.ShowDialog() = DialogResult.OK Then
                GetContacts()
            End If
        End Using
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles btnImportContact.Click
        Using importContactForm As New ImportContact()
            If importContactForm.ShowDialog() = DialogResult.OK Then
                GetContacts()
            End If
        End Using
    End Sub

    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rdByName.CheckedChanged, rdByEmail.CheckedChanged
        SelectSearchByNameOrEmail()
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchValue As String = If(rdByName.Checked, txtByName.Text, txtByEmail.Text)

        If String.IsNullOrWhiteSpace(searchValue) Then
            MessageBox.Show($"Please enter a {(If(rdByName.Checked, "name", "email"))} to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using contactRepo As New ContactRepository()
            contacts = If(rdByName.Checked, contactRepo.SearchContacts(searchValue), contactRepo.SearchContacts(Nothing, searchValue))
            BindContactsToDataGrid()
        End Using
    End Sub


    Private Sub SelectSearchByNameOrEmail()
        If (rdByName.Checked) Then
            txtByEmail.Enabled = False
            txtByName.Enabled = True
        ElseIf (rdByEmail.Checked) Then
            txtByName.Enabled = False
            txtByEmail.Enabled = True
        End If
    End Sub

    Private Sub ButtonLoadAll_Click(sender As Object, e As EventArgs) Handles btnLoadAll.Click
        GetContacts()
    End Sub
End Class
