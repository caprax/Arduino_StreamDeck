Imports System.IO.Ports
Public Class Form1
    'Dim hash As Char = Chr(35)
    'Dim flag As Boolean = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ports As String() = SerialPort.GetPortNames() 'define COM port
        CheckForIllegalCrossThreadCalls = False
        Dim port As String
        For Each port In ports
            SerialPort1.PortName = port
            Label1.Text = SerialPort1.PortName

        Next
        SerialPort1.Open() ' start the serial communication
        '////HANDSHAKE//Failed//
        'If flag = 0 Then
        '    For tryports As Integer = 0 To ports.Length - 1
        '        SerialPort1.PortName = ports(tryports)
        '        Label1.Text = SerialPort1.PortName

        '        SerialPort1.Open()


        '        If SerialPort1.ReadLine(0) = Chr(35) Then

        '            SerialPort1.Write(Chr(35))

        '            Label2.Text = SerialPort1.ReadLine()
        '            flag = 1
        '            Exit For

        '        Else
        '            SerialPort1.Close()
        '            Continue For
        '        End If


        '    Next
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Label1.Text = SerialPort1.IsOpen

    End Sub

    Public Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Label2.Text = SerialPort1.ReadLine(0)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label2_TextChanged(sender As Object, e As EventArgs) Handles Label2.TextChanged
        My.Computer.Keyboard.SendKeys(Label2.Text(0), True)
    End Sub
End Class
