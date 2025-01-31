Imports System.Data.SQLite
Imports TaskManager.Core

Public Class ContactRepository
    Implements IDisposable

    Public Sub Dispose() Implements IDisposable.Dispose
    End Sub

    Public Function InsertContact(contact As Contact) As Boolean
        Using connection As New SQLiteConnection(SQLiteHelper.DBPath)
            connection.Open()
            ' FIX: The order of data in the INSERT command shold match its parameters values.
            Dim insertQuery As String = "INSERT INTO Contact (Name, Email, Phone, Active) VALUES (@Name, @Email, @Phone, @Active)"
            Using command As New SQLiteCommand(insertQuery, connection)
                command.Parameters.AddWithValue("@Name", contact.Name)
                command.Parameters.AddWithValue("@Email", contact.Email)
                command.Parameters.AddWithValue("@Phone", contact.Phone)
                command.Parameters.AddWithValue("@Active", contact.ActiveStatusByNumber)
                command.ExecuteNonQuery()
            End Using
        End Using

        Return True
    End Function

    'https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/bulk-insert
    Public Function InsertContactBulk(contacts As List(Of Contact)) As Boolean
        Using connection As New SQLiteConnection(SQLiteHelper.DBPath)
            connection.Open()
            Dim insertQuery As String = "INSERT INTO Contact (Name, Email, Phone, Active) VALUES ($name, $email, $phone, $active)"

            Try
                Using transaction As SQLiteTransaction = connection.BeginTransaction()
                    Using command As New SQLiteCommand(insertQuery, connection)
                        command.Transaction = transaction

                        Dim nameParameter = command.CreateParameter()
                        nameParameter.ParameterName = "$name"
                        command.Parameters.Add(nameParameter)

                        Dim emailParameter = command.CreateParameter()
                        emailParameter.ParameterName = "$email"
                        command.Parameters.Add(emailParameter)

                        Dim phoneParameter = command.CreateParameter()
                        phoneParameter.ParameterName = "$phone"
                        command.Parameters.Add(phoneParameter)

                        Dim activeParameter = command.CreateParameter()
                        activeParameter.ParameterName = "$active"
                        command.Parameters.Add(activeParameter)

                        For Each contact As Contact In contacts
                            nameParameter.Value = If(contact.Name, DBNull.Value)
                            emailParameter.Value = If(contact.Email, DBNull.Value)
                            phoneParameter.Value = If(contact.Phone, DBNull.Value)
                            activeParameter.Value = contact.ActiveStatusByNumber
                            command.ExecuteNonQuery()
                        Next
                    End Using
                    transaction.Commit()
                End Using
            Catch ex As Exception
                Throw
            End Try
        End Using

        Return True
    End Function

    Public Function UpdateContact(contact As Contact, contactId As Integer) As Boolean
        Using connection As New SQLiteConnection(SQLiteHelper.DBPath)
            connection.Open()
            Dim updateQuery As String = "UPDATE Contact SET Name=@Name, Email=@Email, Phone=@Phone, Active=@Active WHERE Id=@Id"
            Using command As New SQLiteCommand(updateQuery, connection)
                command.Parameters.AddWithValue("@Id", contactId)
                command.Parameters.AddWithValue("@Name", contact.Name)
                command.Parameters.AddWithValue("@Email", contact.Email)
                command.Parameters.AddWithValue("@Phone", contact.Phone)
                command.Parameters.AddWithValue("@Active", contact.ActiveStatusByNumber)
                command.ExecuteNonQuery()
            End Using
        End Using

        Return True
    End Function

    Public Function GetContacts() As List(Of Contact)
        Dim contacts As New List(Of Contact)
        Using connection As New SQLiteConnection(SQLiteHelper.DBPath)
            connection.Open()
            Dim selectQuery As String = "SELECT * FROM Contact"
            Using command As New SQLiteCommand(selectQuery, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        contacts.Add(New Contact() With {.Id = reader("Id"), .Name = reader("Name").ToString(), .Email = reader("Email").ToString(), .Phone = reader("Phone").ToString(), .ActiveStatusByNumber = reader("Active")})
                    End While
                End Using
            End Using
        End Using
        Return contacts
    End Function

    Public Function SearchContacts(Optional name As String = Nothing, Optional email As String = Nothing) As List(Of Contact)
        Dim contacts As New List(Of Contact)
        Using connection As New SQLiteConnection(SQLiteHelper.DBPath)
            connection.Open()
            Dim selectQuery As String = "SELECT * FROM Contact"
            Dim whereClause As String = " WHERE "
            Using command As New SQLiteCommand(connection)
                If (name IsNot Nothing) Then
                    selectQuery += whereClause + "Name LIKE '%' || @Name || '%'"
                    command.Parameters.AddWithValue("@Name", name)
                Else
                    selectQuery += whereClause + "Email LIKE '%' || @Email || '%'"
                    command.Parameters.AddWithValue("@Email", email)
                End If
                command.CommandText = selectQuery
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        contacts.Add(New Contact() With {.Id = reader("Id"), .Name = reader("Name").ToString(), .Email = reader("Email").ToString(), .Phone = reader("Phone").ToString(), .ActiveStatusByNumber = reader("Active")})
                    End While
                End Using
            End Using
        End Using

        Return contacts
    End Function

    ' For multiple search conditions
    'Private Function GetConditions(name As String, email As String) As List(Of String)
    '    Dim conditions As New List(Of String)
    '    If Not String.IsNullOrEmpty(name) Then
    '        conditions.Add("Name LIKE '%' || @Name || '%'")
    '    End If
    '    If Not String.IsNullOrEmpty(email) Then
    '        conditions.Add("Email LIKE '%' || @Email || '%'")
    '    End If
    '    Return conditions
    'End Function

    Public Function GetContactById(id As Integer) As Contact
        Dim contact As New Contact

        Using connection As New SQLiteConnection(SQLiteHelper.DBPath)
            connection.Open()
            Dim selectQuery As String = "SELECT * FROM Contact WHERE Id = @Id"
            Using command As New SQLiteCommand(selectQuery, connection)
                command.Parameters.AddWithValue("@Id", id)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        contact.Name = reader("Name").ToString()
                        contact.Email = reader("Email").ToString()
                        contact.Phone = reader("Phone").ToString()
                        contact.ActiveStatusByNumber = reader("Active").ToString()
                    End If
                End Using
            End Using
        End Using

        Return contact
    End Function
End Class
