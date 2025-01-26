Imports System.IO
Imports TaskManager.Core
Imports TaskManager.Data

Public Class ImportContact
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ButtonBrowseFile_Click(sender As Object, e As EventArgs) Handles btnBrowseFile.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv"
            openFileDialog.Title = "Select a CSV File"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                txtFileName.Text = openFileDialog.FileName
            End If
        End Using
    End Sub

    Private Sub ButtonImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        'Validation for file path
        If String.IsNullOrEmpty(txtFileName.Text) Then
            MessageBox.Show("Please select a file to import.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            If Not File.Exists(txtFileName.Text) Then
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        'Confirmation
        If (MessageBox.Show("Are you sure you want to import the contacts?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            Return
        End If

        If ImportContacts(txtFileName.Text) Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Function ImportContacts(filePath As String) As Boolean
        Dim contacts As New List(Of Contact)()
        Using reader As New StreamReader(filePath)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                Dim values As String() = line.Split(","c)
                contacts.Add(New Contact() With {
                    .Name = values(0),
                    .Email = values(1),
                    .Phone = values(2)
                })
            End While
        End Using

        Using contactRepo As New ContactRepository()
            Try
                contactRepo.InsertContactBulk(contacts)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using

        Return True
    End Function
End Class