Imports System.Xml
Imports System.IO


Module XmlModule
    ''' <summary>
    ''' Employee type.
    ''' </summary>
    Class GridSetiing
        Public Sub New(ByVal Item As String, _
                ByVal ColIndex As Integer, ByVal Width As Integer)
            ' Set fields.

            Me._Item = Item
            Me._ColIndex = ColIndex
            Me._Width = Width
        End Sub

        ' Storage of Grid data.
        Public _Item As String

        Public _ColIndex As Integer
        Public _Width As Integer
    End Class
    Public Sub GridSetiingShowXml(ByVal File_Name As String, ByVal mGrid As DataGridView)
        Dim i As Integer
        Dim m_xmlr As XmlTextReader

        If File.Exists(My.Application.Info.DirectoryPath & "\Setting\" & File_Name & ".xml") = False Then Exit Sub
        m_xmlr = New XmlTextReader(My.Application.Info.DirectoryPath & "\Setting\" & File_Name & ".xml")
        'Disable whitespace so that you don't have to read over whitespaces

        m_xmlr.WhitespaceHandling = WhitespaceHandling.None
        'read the xml declaration and advance to family tag

        m_xmlr.Read()
        'read the family tag

        m_xmlr.Read()
        'Load the Loop

        While Not m_xmlr.EOF
            'Go to the name tag

            m_xmlr.Read()
            'if not start element exit while loop

            If Not m_xmlr.IsStartElement() Then
                Exit While
            End If
            'Get the Gender Attribute Value

            'Dim genderAttribute = m_xmlr.GetAttribute("gender")
            ''Read elements firstname and lastname

            m_xmlr.Read()
            'Get the firstName Element Value

            Dim NameValue = m_xmlr.ReadElementString("Name")
            Dim Mindex = m_xmlr.ReadElementString("Index")
            Dim MWidth = m_xmlr.ReadElementString("Width")

            For i = 0 To mGrid.ColumnCount - 1
                If mGrid.Columns(i).Name = NameValue Then
                    mGrid.Columns(i).DisplayIndex = Mindex
                    mGrid.Columns(i).Width = MWidth
                End If

                '  GridSave(i) = New GridSetiing(mGrid.Columns(i).Name, mGrid.Columns(i).DisplayIndex, mGrid.Columns(i).Width)
            Next



            'Console.WriteLine("Gender: " & genderAttribute _
            '  & " FirstName: " & firstNameValue & " LastName: " _
            '  & lastNameValue)
            Console.Write(vbCrLf)
        End While
        'close the reader

        m_xmlr.Close()
    End Sub
    Public Sub GridSetiingWriteXml(ByVal File_Name As String, ByVal mGrid As DataGridView)
        ' Create array of employees.
        Dim GridSave(0) As GridSetiing
        Dim i As Integer

        For i = 0 To mGrid.ColumnCount - 1
            ReDim Preserve GridSave(i)
            GridSave(i) = New GridSetiing(mGrid.Columns(i).Name, mGrid.Columns(i).DisplayIndex, mGrid.Columns(i).Width)
        Next

        ' Create XmlWriterSettings.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Setting") = False Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Setting")
        End If





        Using writer As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & "\Setting\" & File_Name & ".xml", settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("GridSave") ' Root.

            ' Loop over employees in array.
            Dim Column As GridSetiing
            For Each Column In GridSave
                writer.WriteStartElement("Column")

                writer.WriteElementString("Name", Column._Item)
                writer.WriteElementString("Index", Column._ColIndex.ToString)
                writer.WriteElementString("Width", Column._Width.ToString)
                writer.WriteEndElement()
            Next

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub
End Module