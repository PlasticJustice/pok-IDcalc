﻿Public Class UpdateCheck
    Dim dir As String = My.Application.Info.DirectoryPath
    Dim web As New System.Net.WebClient
    Dim prog As String = dir & "\AutoUpdater.exe"
    Public Sub New()
        InitializeComponent()
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://github.com/PlasticJustice/pokeIDcalc/raw/master/pok%C3%A9IDcalc/bin/Debug/version.txt")
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim newestversion As String = sr.ReadToEnd()
        Dim currentversion As String = Application.ProductVersion
        If newestversion.Contains(currentversion) Then
            'Do nothing
            If System.IO.File.Exists(prog) Then
                System.IO.File.Delete(prog)
            End If
            Close()
        Else
            web.DownloadFileAsync(New Uri("https://github.com/PlasticJustice/pokeIDcalc/raw/master/pok%C3%A9IDcalc/AutoUpdater.exe"), prog)
            Timer1.Start()
        End If
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Process.Start(prog)
        Application.Exit()
    End Sub
End Class