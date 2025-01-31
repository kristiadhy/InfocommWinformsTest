Imports TaskManager.Core
Imports TaskManager.Data

Public Class AddContact
    Dim transactionMode As TransactionMode.TransactionType
    Dim contactId As Integer

    ' The default class consctructor
    Public Sub New()
        InitializeComponent()
        transactionMode = UI.TransactionMode.TransactionType.Add
        chkActive.Checked = True
    End Sub

    ' Another class conscrtuctor with specific parameter. It's a constructor overloading.
    Public Sub New(contactId As Integer)
        InitializeComponent()
        transactionMode = UI.TransactionMode.TransactionType.Edit
        Me.contactId = contactId
        btnAdd.Text = "Update Contact"

        If (transactionMode = UI.TransactionMode.TransactionType.Edit) Then
            LoadContactById()
        End If
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If (ContactValidation() = False) Then
            Return
        End If

        Dim contact As New Contact() With {
            .Name = txtName.Text,
            .Email = txtEmail.Text,
            .Phone = txtPhone.Text,
            .ActiveStatusByNumber = If(chkActive.Checked, 1, 0)
            }

        ' For add transction
        If (transactionMode = UI.TransactionMode.TransactionType.Add) Then
            Using contactRepo As New ContactRepository()
                contactRepo.InsertContact(contact)
            End Using

            'For edit transaction
        ElseIf (transactionMode = UI.TransactionMode.TransactionType.Edit) Then
            Using contactRepo As New ContactRepository()
                contactRepo.UpdateContact(contact, contactId)
            End Using
        End If

        ClearControls()
        'Close()
        DialogResult = DialogResult.OK
    End Sub

    Private Sub ClearControls()
        txtName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        chkActive.Checked = False
    End Sub

    Private Sub LoadContactById()
        Using contactRepo As New ContactRepository()
            Dim existingContact = contactRepo.GetContactById(contactId)
            txtName.Text = existingContact.Name
            txtEmail.Text = existingContact.Email
            txtPhone.Text = existingContact.Phone
            chkActive.Checked = existingContact.Active
        End Using
    End Sub

    Private Function ContactValidation() As Boolean
        Dim errorMessage As String = String.Empty

        If String.IsNullOrEmpty(txtName.Text) Then
            errorMessage &= "- Please enter the name." & Environment.NewLine
        End If
        If String.IsNullOrEmpty(txtEmail.Text) Then
            errorMessage &= "- Please enter the email." & Environment.NewLine
        End If
        If String.IsNullOrEmpty(txtPhone.Text) Then
            errorMessage &= "- Please enter the phone number." & Environment.NewLine
        End If

        If Not String.IsNullOrEmpty(errorMessage) Then
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function
End Class