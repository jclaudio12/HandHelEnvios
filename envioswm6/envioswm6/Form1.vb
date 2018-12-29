'LIBRERIAS REQUERIDAS POR LA APLICACION ORIGINAL
Imports System.Data.SqlServerCe
Imports System.IO.File
Imports System
'LIBRERIAS IMPORTADAS REQUERIDAS POR GPS
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.Data
Imports Sega.WindowsMobile.GPS
Imports System.Data.Common.DbConnection
Imports System.Data.Common.DbDataAdapter
Imports System.Data.Common.DbCommand
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports System.Text
Imports ZSDK_API.Printer
Imports System.IO
Imports InTheHand.net
Imports System.Runtime.InteropServices
Imports ZSDK_API.Comm
Imports ZSDK_API.ApiException
Imports InTheHand.Net.Sockets
Imports InTheHand.Net.Bluetooth
'f_imp_previa()
Public Class Form1
    Public SUPER As Integer = 0
    Public v_empresa As String = Nothing
    'Public Const NombreBaseDeDatos As String = "\campo.sdf"
    'Public Const BASEINS As String = "\envios.sdf"
    'Public Const NOMBREBD As String = "\valida.sdf"
    'Public Const BASETURNO As String = "\BITACORA.SDF"
    Public Const NombreBaseDeDatos As String = "campo.sdf"
    Public Const BASEINS As String = "envios.sdf"
    Public Const NOMBREBD As String = "valida.sdf"
    Public Const BASETURNO As String = "BITACORA.SDF"
    Dim estado As Integer = 0
    Dim valida2 As Integer = 0
    'Public DirectorioDeAplicacion As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
    'Public DirectorioDeAplicacion As String = "IPSM"
    Public DirectorioDeAplicacion As String = "\"
    'con esto obtengo el directorio donde se esta ejecutando la aplicacion
    'Variables a utilizar en el dispositivo GPS
    Private updateDataHandler As EventHandler
    Dim device As GpsDeviceState = Nothing
    Dim position As GpsPosition = Nothing
    Dim DMS As DegreesMinutesSeconds = Nothing
    'VARIABLES DEFINIDAS PARA APLICACION ORIGINAL
    Dim gps As Sega.WindowsMobile.GPS.Gps = New Sega.WindowsMobile.GPS.Gps()
    Public VALIDA As Integer = 0
    Public texto As String
    Public indice As Integer
    Public A As Integer
    Public IMPRESIONES As Integer = 1
    Public IMPRESIONES2 As Integer = 0
    Public IMPRESIONPRE As Integer = 0
    Public bandera As Integer = 0
    Public v_previa As Integer = 0
    Public linea_archivo As String
    Public numero_archivo As Integer
    Public serie_archivo As String
    Public serie_preparada As String
    Public detalle As String = ""
    Public NUMERO_REP As Integer
    Public TEJON As Integer = 0
    Public TIPO As String = ""
    Public TOTAL_PRECIO As Double = 0
    Delegate Sub myInvokedMethod(ByVal buffer As String)
    Public finca As String
    Public frente As String
    Public pante As String
    Public lote As String
    Public nombre_trans As String
    Public placa_vehi As String
    Public nombre_pilo As String
    Public ticket As String
    Public nombre_contra As String
    Public despacho As String
    Public lotes As String
    Public medida As String
    Public total_unidades As Integer
    Public total_detalle As Integer
    Public total_tonelada As Double
    Public total_deta_u As Integer
    Public total_deta_c As Integer
    Public subtotal_deta_c As Integer
    Public conteo As Integer
    Public TOTAL_SACOS As Integer = 0
    Public lote1 As String
    Public lote2 As String
    Public lote3 As String
    Public lote4 As String
    Public lote5 As String
    Public lote6 As String
    Public pante1 As String
    Public pante2 As String
    Public pante3 As String
    Public pante4 As String
    Public pante5 As String
    Public pante6 As String
    Public fechaq1 As String
    Public fechaq2 As String
    Public fechaq3 As String
    Public fechaq4 As String
    Public fechaq5 As String
    Public fechaq6 As String
    Public horaq5 As String
    Public horaq6 As String
    Public horaq1 As String
    Public horaq2 As String
    Public horaq3 As String
    Public horaq4 As String
    Public unidad1 As String
    Public flete As String
    Public fecha_env As String
    Public enviero As String
    Public alzador As String
    Public tractor As String
    Public opera_alz As String
    Public opera_tra As String
    Public fecha_turno As String
    Public presentacion As String
    Public nombre_empresa As String
    Public IMP As String
    Public ENC As String
    Public coordenada As Integer
    Public corte As Double
    Public salto As Integer
    Public linea As String
    Public NOMBRE_BOLETA As String
    Public CONTADOR As Integer
    Public total_bruto As Double
    Public total_tara As Double
    Public total_neto As Double
    Public contador_recibe As Integer
    Public acumulador As Integer = 0
    Public registro As Integer = 0
    Public largo As Integer = 0
    Public EDICION As String = Nothing
    Public proceso As Process
    Public navegar As Integer = 0
    Public detallegc As String = ""
    Public tipotserie As String = ""
    Public count_carga_env As Integer = 0
    Public lv_unidad As Integer = 0
    Public numerou1new As Integer
    Public p_placa As String = "-"
    Public p_placa_manu As String
    Public v_sticket As Integer = 0
    Dim VARIEDAD_DESC As String = Nothing
    ''variables para reimpresion
    Public Shared ReadOnly DBnull As Object
    'Delegate Sub myInvokedMethod(ByVal buffer As String)
    Dim mingo As Object = Convert.DBNull
    Public vr_empresa As String
    Public vr_usuario As String
    Public vr_finca As String
    Public vr_frente As String
    Public vr_pante As String
    Public vr_lote As String
    Public vr_nombre_finca As String
    Public vr_trans As String
    Public vr_vehi As String
    Public vr_pilo As String
    Public vr_nombre_trans As String
    Public vr_placa_vehi As String
    Public vr_nombre_pilo As String
    Public vr_ticket As String
    Public vr_cole As String
    Public vr_contratista As String
    Public vr_nombre_contra As String
    Public vr_plata As String
    Public vr_despacho As String
    Public vr_lotes As String
    Public vr_tipo As String
    Public vr_medida As String
    Public vr_lote1 As String
    Public vr_lote2 As String
    Public vr_lote3 As String
    Public vr_lote4 As String
    Public vr_lote5 As String
    Public vr_lote6 As String
    Public vr_pante1 As String
    Public vr_pante2 As String
    Public vr_pante3 As String
    Public vr_pante4 As String
    Public vr_fechaq1 As String
    Public vr_fechaq2 As String
    Public vr_fechaq3 As String
    Public vr_fechaq4 As String
    Public vr_fechaq5 As String
    Public vr_fechaq6 As String
    Public vr_horaq1 As String
    Public vr_horaq2 As String
    Public vr_horaq3 As String
    Public vr_horaq4 As String
    Public vr_horaq5 As String
    Public vr_horaq6 As String
    Public vr_unidad1 As String
    Public vr_unidad2 As String
    Public vr_unidad3 As String
    Public vr_unidad4 As String
    Public vr_unidad5 As String
    Public vr_unidad6 As String
    Public vr_grupo As String
    Public vr_flete As String
    Public vr_fecha_env As String
    Public vr_linea_archivo As String
    Public vr_ruta As String
    Public vr_enviero As String
    Public vr_alzador As String
    Public vr_tractor As String
    Public vr_opera_alz As String
    Public vr_opera_tra As String
    Public vr_peri As String
    Public Const vr_NOMBREBD As String = "\envios.sdf"
    Public Const vr_NOMBREBD2 As String = "\campo.sdf"
    Public vr_DirectorioDeAplicacion As String = "IPSM"
    'Public vr_DirectorioDeAplicacion As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
    Public vr_nombre_empresa As String
    Public vr_IMP As String
    Public vr_ENC As String
    Public vr_UNIDADES As String
    Public vr_NOMBRE_BOLETA As String
    Public vr_texto As String
    Public vr_serie_archivo As String
    Public vr_serie_preparada As String
    Public vr_zona As String
    Public vr_linea As String
    Public vr_EDICION As String = Nothing
    Public vr_coordenada As Integer
    Public vr_corte As Double
    Public vr_salto As Integer
    Public vr_lectura As Integer
    Public vr_CONTADOR As Integer
    Public vr_total_bruto As Double
    Public vr_total_tara As Double
    Public vr_total_neto As Double
    Public vr_contador_recibe As Integer
    Public vr_acumulador As Integer = 0
    Public vr_registro As Integer = 0
    Public vr_largo As Integer = 0
    Public vr_impresiones As Integer = 1
    Public vr_proceso As Process
    Public vr_navegar As Integer = 0
    Public vr_numero_archivo As Integer
    Public vr_total_unidades As Integer
    Public vr_total_detalle As Integer
    Public vr_GENERADO As String
    Public vr_DETALLE As String = ""
    Public usua As String = Nothing
    Public turnop As Integer
    Dim tipo_can As String = Nothing
    Public fe_quema_old As String = "15102014"
    Public pg_estado As Integer = 0
    Public pg_estado_v2 As Integer = 0
    ''terminan las variables para reimpresion
    Public Function Lpad(ByVal MyValue$, ByVal MyPadCharacter$, ByVal MyPaddedLength%) As String
        Dim padlength As Integer
        padlength = MyPaddedLength - Len(MyValue)
        Dim PadString As String = ""
        For x = 1 To padlength
            PadString = PadString & MyPadCharacter
        Next
        Lpad = PadString + MyValue
    End Function
    Private Sub numero_reporte()
        serie_new.Text = serie_preparada
        Dim exeserie As String = Nothing
        If serie_new.Text.Length > 0 Then
            exeserie = Convert.ToString(serie_new.Text)
        Else
            exeserie = Nothing
        End If
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim QUERY = New SqlCeCommand("SELECT COUNT(ENVIO)+1 FROM TB_ENVIOS WHERE SERIE = '" + exeserie + "';", CONN)
        Dim query2 = New SqlCeCommand("SELECT MAX(ENVIO)+1 FROM TB_ENVIOS WHERE SERIE = '" + exeserie + "';", CONN)
        'Dim QUERY = New SqlCeCommand("SELECT COUNT(id_movimiento)+1 FROM TB_MOVIMIENTO;", CONN)
        'Dim query2 = New SqlCeCommand("select max(id_movimiento)+1 FROM TB_MOVIMIENTO WHERE ID_SERIE= '" + exeserie + "';", CONN)Dim dr As SqlCeDataReader = Nothing
        Dim dr As SqlCeDataReader = Nothing
        Dim DR2 As SqlCeDataReader = Nothing
        Dim valor As Integer = Nothing
        Try
            CONN.Open()
            dr = QUERY.ExecuteReader()
            While dr.Read()
                ' valor = Convert.ToInt32(dr(0).ToString) > 1
                valor = Convert.ToInt32(dr(0).ToString)
                If valor > 1 Then
                    DR2 = query2.ExecuteReader()
                    While DR2.Read()
                        NUMERO_REP = Convert.ToInt32(DR2(0).ToString)
                    End While
                ElseIf valor = 1 Then
                    NUMERO_REP = 1
                Else
                    NUMERO_REP = Convert.ToInt32(dr(0).ToString)
                End If
            End While
        Catch ex As Exception
            MsgBox("Error ocasionado por 1" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub
    Private Sub createxto()
        Dim oFile As System.IO.File = Nothing
        Dim oWrite As System.IO.StreamWriter
        If IO.File.Exists("IPSM\reporte.dat") Then
            oWrite = IO.File.CreateText("IPSM\reporte.dat")
            oWrite.Write(numero_archivo + 1)
            oWrite.Close()
        Else
            IO.File.Create("IPSM\reporte.dat")
            oWrite = IO.File.CreateText("IPSM\reporte.dat")
            oWrite.Write("1")
            oWrite.Close()
        End If
    End Sub
    Private Sub leertexto()
        Dim ofile As System.IO.File = Nothing
        Dim oRead As System.IO.StreamReader
        If IO.File.Exists("IPSM\reporte.dat") Then
            oRead = IO.File.OpenText("IPSM\reporte.dat")
            linea_archivo = oRead.ReadLine()
            numero_archivo = Convert.ToInt32(linea_archivo)
            oRead.Close()
        Else
            Dim owrite As System.IO.StreamWriter
            IO.File.Create("IPSM\reporte.dat")
            owrite = IO.File.CreateText("IPSM\reporte.dat")
            owrite.Write("1")
            owrite.Close()
        End If
    End Sub
    Private Sub SERIE_ENVIO()
        Dim oFile As System.IO.File = Nothing
        Dim oRead As System.IO.StreamReader
        If IO.File.Exists("IPSM\serie.txt") Then
            oRead = IO.File.OpenText("IPSM\serie.txt")
            serie_archivo = oRead.ReadLine()
            serie_preparada = serie_archivo.Trim
            TIPO = "E"
        End If
    End Sub
    'Private Sub SERIE_ENVIO_NEW()
    '    Dim oFile As System.IO.File = Nothing
    '    Dim oRead As System.IO.StreamReader
    '    If IO.File.Exists("IPSM\serie.txt") Then
    '        oRead = IO.File.OpenText("IPSM\serie.txt")
    '        serie_archivo = oRead.ReadLine()
    '        serie_preparada = serie_archivo.Trim
    '        tipot.Text = serie_preparada + tipot.Text
    '        TIPO = "E"
    '    End If
    'End Sub


    ''' <summary>
    '''  boton de seleccion caña en forma de seleccion
    ''' </summary>

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Empresa.Text = "1"
        carga_tipo_envio()
        coleccion.TabPages.Item(1).BringToFront()
        coleccion.SelectedIndex = 1
    End Sub
    ''' <summary>
    ''' boton de seleccion de palma en forma seleccion
    ''' </summary>

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Empresa.Text = "6327"
        carga_tipo_envio()
        coleccion.TabPages.Item(1).BringToFront()
        coleccion.SelectedIndex = 1
    End Sub

    Private Sub Granel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Granel.CheckedChanged
        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else

            If ((Granel.Checked = True) And (Empresa.Text = "1")) Then
                tipot.Text = "G"
                cole_mal.Text = ""
                tipotserie = "G"
                'SERIE_ENVIO_NEW()
            ElseIf ((Granel.Checked = True And Empresa.Text = "6327")) Then
                tipot.Text = "U"
                cole_mal.Text = ""
            End If
        End If
        'carga_ingreso_finca()
        'coleccion.TabPages.Item(2).BringToFront()
        'coleccion.SelectedIndex = 2
    End Sub

    Private Sub carga_transporte()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim QUERY = New SqlCeCommand("SELECT * FROM TB_PARAMETROS;", CONN)
        Dim dr As SqlCeDataReader = Nothing
        Try
            CONN.Open()
            dr = QUERY.ExecuteReader()
            While dr.Read()
                ALZ.Text = dr(0).ToString
                TRA.Text = dr(2).ToString
                OPA.Text = dr(1).ToString
                OPT.Text = dr(3).ToString
                ENV.Text = dr(4).ToString
            End While
        Catch ex As Exception
            MsgBox("Error ocasionado por 2" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
        Tipo_boleta.Text = tipot.Text
        id_transportista.Text = trans.Text
        id_vehiculo.Text = vehi.Text
        Id_piloto.Text = pilo.Text
        Id_ticket.Text = Nboleta.Text
        id_transportista.Focus()
        id_vehiculo.Focus()
        Id_piloto.Focus()
        Id_ticket.Focus()
        ENV.Text = usuario.Text
        If tipot.Text = "L" Then
            cole.Visible = False
            'Label6.Visible = False
            ALZ.Visible = False
            TRA.Visible = False
            OPA.Visible = False
            OPT.Visible = False
            Label17.Visible = False
            Label18.Visible = False
            Label27.Visible = False
            Label28.Visible = False
            'Label11.Visible = False
            'plata.Focus()
            Button7.Visible = False
        ElseIf tipot.Text = "T" Then
            plata.Visible = False
            cole.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            ALZ.Visible = False
            TRA.Visible = False
            OPA.Visible = False
            OPT.Visible = False
            Label18.Visible = False
            Label17.Visible = False
            Label27.Visible = False
            Label28.Visible = False
            Button7.Visible = False
        ElseIf tipot.Text = "M" Then
            Contratista.Visible = False
            id_contratista.Visible = False
            Label7.Visible = False
            ALZ.Visible = False
            TRA.Visible = False
            OPA.Visible = False
            OPT.Visible = False
            Label18.Visible = False
            Label17.Visible = False
            Label27.Visible = False
            Label28.Visible = False
            Button7.Visible = False
            'Id_ticket.Focus()
        ElseIf tipot.Text = "U" Then
            Nombre_transportista.Visible = True
            Placa.Visible = True
            Piloto.Visible = True
            Contratista.Visible = True
            Id_ticket.Visible = False            
            cole.Visible = False
            Label6.Visible = False
            ALZ.Visible = False
            TRA.Visible = False
            OPA.Visible = False
            OPT.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            Label11.Visible = False
            Dim coordenada As System.Drawing.Point
            coordenada.X = 61
            coordenada.Y = 215
            Button2.Location = coordenada
            coordenada.X = 97
            coordenada.Y = 215
            Salir.Location = coordenada
            coordenada.X = 142
            coordenada.Y = 215
            Button1.Location = coordenada
            plata.Focus()
        ElseIf tipot.Text = "V" Then
            Nombre_transportista.Visible = True
            Placa.Visible = True
            Piloto.Visible = True
            Contratista.Visible = True
            Id_ticket.Visible = False                        
            cole.Visible = False
            Label6.Visible = False
            ALZ.Visible = False
            TRA.Visible = False
            OPA.Visible = False
            OPT.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            Label11.Visible = False
            Dim coordenada As System.Drawing.Point
            coordenada.X = 61
            coordenada.Y = 215
            Button2.Location = coordenada
            coordenada.X = 97
            coordenada.Y = 215
            Salir.Location = coordenada
            coordenada.X = 142
            coordenada.Y = 215
            Button1.Location = coordenada
            plata.Focus()
        End If
    End Sub
    Private Sub carga_tipo_envio()
        If Not gps.Opened Then
            gps.Open()
        End If
        If Empresa.Text = "6327" Then
            Granel.Text = "Fabrica"
            Colera.Text = "Venta"
            Colera.Visible = True
            Colera.Enabled = True
            Maleteado.Visible = False
            Maleteado.Enabled = False
            Mecanizado.Visible = False
            Mecanizado.Enabled = False
            Trameado.Visible = False
            Trameado.Enabled = False
        End If
    End Sub
    Private Sub carga_lectura()
        If (tipot.Text = "T") Then
            plata.Text = "0"
            cole.Text = "0"
        End If
        If ((Empresa.Text = "6326") Or (Empresa.Text = "6327")) Then
            LRUTA.Visible = False
            id_ruta.Visible = False
            If tipot.Text <> "G" Or tipot.Text <> "C" Then
                Colera.Visible = False
                If tipot.Text = "L" Then
                    plata.Visible = False
                End If
                Label25.Visible = False
                Label26.Visible = False
            End If
        End If
        If Liturno.SelectedIndex >= 0 Then
            grupo.Text = Liturno.Items.Item(Liturno.SelectedIndex)
        End If
    End Sub
    Private Sub carga_ingreso_finca()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim QUERY = New SqlCeCommand("SELECT * FROM TB_PARAMETROS;", CONN)
        Dim dr As SqlCeDataReader = Nothing
        Dim present As String = "C"
        Try
            CONN.Open()
            dr = QUERY.ExecuteReader()
            While dr.Read()
                Dim algo As DateTime = Nothing
                algo = Convert.ToDateTime(dr(5).ToString)
                fecturno.Text = algo.ToString("ddMMyyyy")
                'Lizona.SelectedValue = dr(6).ToString
                'Lizona.SelectedIndex(Lizona.Items.Item = dr(6))
                Lizona.SelectedItem = dr(6)
                present = Convert.ToString(dr(7)).ToString
                If (present = "Q") Then
                    presenta.Checked = True
                    presentanew.Text = "Q"
                ElseIf (present = "") Then
                    presenta.Checked = False
                    presentanew.Text = "C"
                Else
                    presenta.Checked = False
                End If
            End While
        Catch ex As Exception
            MsgBox("Error ocasionado por 3" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
        If tipot.Text = "C" Or tipot.Text = "G" Then
            tipo_can = "GRA."
            unidades.Text = "Uñadas"
            Label8.Visible = True
            Label8.Text = "Turno"
            grupo.Visible = False
            Liturno.Visible = True
            Liturno.SelectedItem = "A"
            fecturno.Visible = True
            fecturnop.Visible = True
            lcroquis.Visible = True
            Croquis.Visible = True
            zona.Visible = False
            'Lizona.SelectedIndex = 1

        ElseIf tipot.Text = "L" Then
            tipo_can = "MAL."
            Label8.Text = "Turno"
            unidades.Text = "Maletas"
            zona.Visible = False
            'Lizona.SelectedIndex = 1
            Liturno.Visible = True
            Liturno.SelectedItem = "A"
            grupo.Visible = False
        ElseIf tipot.Text = "M" Then
            tipo_can = "MEC."
            unidades.Text = "Carretas"
            Label8.Text = "Turno"
            lcroquis.Visible = True
            Croquis.Visible = True
            locorte.Visible = True
            ocorte.Visible = True
            zona.Visible = False
            'Lizona.SelectedIndex = 1
            Liturno.Visible = True
            Liturno.SelectedItem = "A"
            grupo.Visible = False
        ElseIf tipot.Text = "T" Then
            tipo_can = "TRAM."
            unidades.Text = "Maletas"
            Label8.Visible = True
            Label8.Text = "Cuadrilla"
            zona.Visible = False
            'Lizona.SelectedIndex = 1
            Liturno.Visible = False
            'Liturno.SelectedItem = "A"
            'grupo.Visible = False
        ElseIf tipot.Text = "U" Then
            unidades.Text = "Canastas"
            Label2.Text = "Sector"
            grupo.Visible = True
            Label8.Visible = True            
            Label3.Text = "Variedad"
            Label5.Text = "F. Corte"
            ruta.Visible = False ' YA ESTAN OCULTOS
            Label9.Visible = False ' YA ESTAN OCULTOS
            lzona.Visible = False
            zona.Visible = False
            Lizona.Visible = False
            lfechat.Visible = False
            presenta.Visible = False
            'Lizona.SelectedIndex = 1
            Liturno.Visible = False
        ElseIf tipot.Text = "V" Then
            unidades.Text = "Racimos"
            Label2.Text = "Sector" 'frente
            grupo.Visible = True
            Label8.Visible = True            
            Label3.Text = "Variedad"
            Label5.Text = "F. Corte"
            ruta.Visible = False ' YA ESTAN OCULTOS
            Label9.Visible = False ' YA ESTAN OCULTOS
            lzona.Text = "Sacos" 'zona
            lzona.Visible = True
            zona.Visible = True
            Lizona.Visible = False
            presenta.Visible = False
            lfechat.Visible = False
            'Lizona.SelectedIndex = 1
            Liturno.Visible = False
        End If
        Ho_des.Text = Now.ToString("hhmm")   'Now.TimeOfDay.ToString
        Tipo_boleta.Text = tipot.Text
        hora2.Text = ""
        hora3.Text = ""
        hora4.Text = ""
        hora5.Text = ""
        hora6.Text = ""
        quema2.Text = ""
        quema3.Text = ""
        quema4.Text = ""
        quema5.Text = ""
        quema6.Text = ""
        ''Comienza codigo de combobox
        ''/*Genero el combobox insetandole datos de una tabla de la bd
        'Dim Dt As DataTable
        ''Mi coneccion
        'Dim cn As New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        'Try
        '    Dim Da As New SqlCeDataAdapter
        '    Dim Cmd As New SqlCeCommand
        '    'Query obtiene los datos de las tablas solicitada
        '    With Cmd
        '        .CommandType = Data.CommandType.Text
        '        If tipot.Text = "M" Then
        '            .CommandText = "Select * From tb_frentes where abreviatura = 'MEC.'"
        '        ElseIf tipot.Text = "T" Then
        '            .CommandText = "Select * From tb_frentes where abreviatura = 'TRAM.'"
        '        ElseIf tipot.Text = "C" Or tipot.Text = "G" Then
        '            .CommandText = "Select * From tb_frentes where abreviatura = 'GRA.'"
        '        ElseIf tipot.Text = "L" Then
        '            .CommandText = "Select * From tb_frentes where abreviatura = 'MAL.'"
        '        End If
        '        '--
        '        .Connection = cn
        '    End With 'End query
        '    Da.SelectCommand = Cmd
        '    Dt = New DataTable
        '    Da.Fill(Dt)
        '    'With ComboBox1
        '    '.DataSource = Dt                'Obtiene o establece el origen de datos de este objeto ComboBox.
        '    '.DisplayMember = "id_frente"    'Obtiene o establece la propiedad que se va a mostrar.
        '    '.ValueMember = "id_frente"      'Obtiene o establece la propiedad que se utilizará como valor real.
        '    'End With
        'Catch ex As Exception
        '    MsgBox("Error a cargar los Frentes, Reportarlo")
        'End Try
        ''fin prueba
    End Sub

    Private Sub Colera_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Colera.CheckedChanged

        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else
            If ((Colera.Checked = True) And (Empresa.Text = "1")) Then
                tipot.Text = "C"
                cole_mal.Text = ""
                tipotserie = "C"
                'SERIE_ENVIO_NEW()
                'envia_datos()
            ElseIf ((Colera.Checked = True) And (Empresa.Text = "6327")) Then
                tipot.Text = "V"
                Empresa.Text = "6326"
                cole_mal.Text = ""
                'envia_datos()
            End If
        End If
        'carga_ingreso_finca()
        'coleccion.TabPages.Item(2).BringToFront()
        'coleccion.SelectedIndex = 2
    End Sub

    Private Sub Maleteado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Maleteado.CheckedChanged

        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else
            If Maleteado.Checked = True Then
                tipot.Text = "L"
                cole_mal.Text = ""
                tipotserie = "L"
                'SERIE_ENVIO_NEW()
                'envia_datos()
            End If
        End If
        'carga_ingreso_finca()
        'coleccion.TabPages.Item(2).BringToFront()
        'coleccion.SelectedIndex = 2
    End Sub

    Private Sub Mecanizado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mecanizado.CheckedChanged
        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else
            If Mecanizado.Checked = True Then
                tipot.Text = "M"
                cole_mal.Text = ""
                tipotserie = "M"
                cole_meca.Text = ""
                'SERIE_ENVIO_NEW()
                'envia_datos()
            End If
        End If
        'carga_ingreso_finca()
        'coleccion.TabPages.Item(2).BringToFront()
        'coleccion.SelectedIndex = 2
    End Sub

    Private Sub Trameado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Trameado.CheckedChanged
        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else
            If Trameado.Checked = True Then
                tipot.Text = "T"
                cole_mal.Text = ""
                tipotserie = "T"
                'SERIE_ENVIO_NEW()
                'envia_datos()
            End If
        End If
        'carga_ingreso_finca()
        'coleccion.TabPages.Item(2).BringToFront()
        'coleccion.SelectedIndex = 2
    End Sub
    Private Sub Maleteado_Colera_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Maleteado_Colera.CheckedChanged
        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else
            If Maleteado_Colera.Checked = True Then
                tipot.Text = "L"
                cole_mal.Text = "1"
                tipotserie = "L"
                'SERIE_ENVIO_NEW()
            End If
        End If
    End Sub

    Private Sub Id_finca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Id_finca.LostFocus
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drp As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        lipa1.Items.Clear()
        lilo1.Items.Clear()
        lipa2.Items.Clear()
        lilo2.Items.Clear()
        lipa3.Items.Clear()
        lilo3.Items.Clear()
        lipa4.Items.Clear()
        lilo4.Items.Clear()
        lipa5.Items.Clear()
        lilo5.Items.Clear()
        lipa6.Items.Clear()
        lilo6.Items.Clear()
        If Id_finca.Text.Length > 0 Then
            Try
                Dim valor As Integer = Nothing

                '---
                valor = Convert.ToInt32(Id_finca.Text)
                If valor < 0 Then
                    MsgBox("ingrese numeros")
                    nfinca = 0
                Else
                    nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                    If tipot.Text <> "U" Then
                        Dim QUERYp = New SqlCeCommand("Select id_pante FROM TB_PANTES WHERE (ID_FINCA = " & nfinca & " AND estado = 'ACT' );", CONN)
                        Dim pantes As Integer = 0
                        CONN.Open()
                        drp = QUERYp.ExecuteReader()
                        While drp.Read()
                            lipa1.Items.Add(drp(0).ToString.Trim)
                            lipa2.Items.Add(drp(0).ToString.Trim)
                            lipa3.Items.Add(drp(0).ToString.Trim)
                            lipa4.Items.Add(drp(0).ToString.Trim)
                            lipa5.Items.Add(drp(0).ToString.Trim)
                            lipa6.Items.Add(drp(0).ToString.Trim)
                            pantes = pantes + 1
                        End While
                        If pantes = 0 Then
                            lipa1.Items.Add(0)
                            lipa2.Items.Add(0)
                            lipa3.Items.Add(0)
                            lipa4.Items.Add(0)
                            lipa5.Items.Add(0)
                            lipa6.Items.Add(0)
                        End If
                    ElseIf (tipot.Text = "U") Then
                        Dim QUERYQ = New SqlCeCommand("Select id_LOte FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & " AND ID_PANTE = 1 AND estado = 'ACT' );", CONN)
                        Dim pantes1 As Integer = 0
                        CONN.Open()
                        drp = QUERYQ.ExecuteReader()
                        While drp.Read()
                            lipa1.Items.Add(drp(0).ToString.Trim)
                            lipa2.Items.Add(drp(0).ToString.Trim)
                            lipa3.Items.Add(drp(0).ToString.Trim)
                            lipa4.Items.Add(drp(0).ToString.Trim)
                            lipa5.Items.Add(drp(0).ToString.Trim)
                            lipa6.Items.Add(drp(0).ToString.Trim)
                            pantes1 = pantes1 + 1
                        End While
                        If pantes1 = 0 Then
                            lipa1.Items.Add(0)
                            lipa2.Items.Add(0)
                            lipa3.Items.Add(0)
                            lipa4.Items.Add(0)
                            lipa5.Items.Add(0)
                            lipa6.Items.Add(0)
                        End If
                    End If
                End If
                '---
                valor = Convert.ToInt32(Id_finca.Text)
                If valor < 0 Then
                    MsgBox("ingrese numeros")
                End If
                'SELECT NOMBRE FROM TB_FINCAS WHERE ID_FINCA = 
                Dim QUERY = New SqlCeCommand("SELECT NOMBRE, SLATITUD, SLONGITUD, NLATITUD, NLONGITUD, ELATITUD, ELONGITUD, OLATITUD, OLONGITUD, ID_TIPO_FINCA FROM TB_FINCAS WHERE ID_FINCA =" & Convert.ToInt32(Id_finca.Text.Trim) & " AND (ESTADO = 'ACT') AND (ID_ENTIDAD_EMPRESA = 1);", CONN)
                If Empresa.Text.Trim = "1" Then
                    QUERY = New SqlCeCommand("SELECT NOMBRE, SLATITUD, SLONGITUD, NLATITUD, NLONGITUD, ELATITUD, ELONGITUD, OLATITUD, OLONGITUD, ID_TIPO_FINCA FROM TB_FINCAS WHERE ID_FINCA =" & Convert.ToInt32(Id_finca.Text.Trim) & " AND (ESTADO = 'ACT') AND (ID_ENTIDAD_EMPRESA = 1);", CONN)
                Else
                    QUERY = New SqlCeCommand("SELECT NOMBRE, SLATITUD, SLONGITUD, NLATITUD, NLONGITUD, ELATITUD, ELONGITUD, OLATITUD, OLONGITUD, ID_TIPO_FINCA FROM TB_FINCAS WHERE ID_FINCA =" & Convert.ToInt32(Id_finca.Text.Trim) & " AND (ESTADO = 'ACT') AND (ID_ENTIDAD_EMPRESA > 6325);", CONN)
                End If

                'CONN.Open()
                dr = QUERY.ExecuteReader()
                While dr.Read()
                    Nombre_finca.Text = dr(0).ToString
                    tipo_finca.Text = dr(9).ToString
                    txtLat1.Text = Replace(Replace(dr(1).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLon1.Text = Replace(Replace(dr(2).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLat2.Text = Replace(Replace(dr(7).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLon2.Text = Replace(Replace(dr(8).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLat3.Text = Replace(Replace(dr(3).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLon3.Text = Replace(Replace(dr(4).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    TxtLat4.Text = Replace(Replace(dr(5).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    TxtLon4.Text = Replace(Replace(dr(6).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                End While
                'If Nombre_finca.TextLength > 0 Then
                '    Id_Frente.Focus()
                'Else
                '    Id_finca.Focus()
                'End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                Id_finca.Focus()
                Id_finca.Text = "0"
                MsgBox("Error ocasionado por 4" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
        End If
        CONN.Close()
    End Sub

    Private Sub Id_Frente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Id_Frente.LostFocus
        Dim valor As Integer = Nothing
        Try
            If Nombre_finca.Text = "" Then
                Id_finca.Focus()
            Else
                valor = Convert.ToInt32(Id_Frente.Text)
                If valor < 0 Then
                    MsgBox("ingrese numeros")
                    Id_Frente.Focus()
                Else
                    valida_frentes()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            Id_Frente.Focus()
            Id_Frente.Text = "0"
        End Try
    End Sub
    Private Sub valida_frentes()
        If tipot.Text = "M" Then
            valida_frente_meca()
            '    .CommandText = "Select * From tb_frentes where abreviatura = 'MEC.'"
        ElseIf tipot.Text = "T" Then
            valida_frente_tra()
            '    .CommandText = "Select * From tb_frentes where abreviatura = 'TRAM.'"
        ElseIf tipot.Text = "C" Or tipot.Text = "G" Then
            valida_frente_gra()
            '    .CommandText = "Select * From tb_frentes where abreviatura = 'GRA.'"
        ElseIf tipot.Text = "L" Then
            valida_frente_mal()
            '    .CommandText = "Select * From tb_frentes where abreviatura = 'MAL.'"
        End If
    End Sub
    Private Sub valida_frente_meca()
        If Id_Frente.Text <> "0" Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim ln_count As Integer = Nothing
            Try
                If (Id_Frente.TextLength > 0) Then
                    Dim valor As Integer = Nothing
                    Try
                        valor = Convert.ToInt32(Id_Frente.Text)
                        If valor < 0 Then
                            MsgBox("ingrese numeros")
                        Else
                            CONN.Open()
                            Dim Querycount = New SqlCeCommand("SELECT COUNT(id_frente) FROM TB_FRENTES WHERE ID_FRENTE = " & valor & " AND abreviatura = 'MEC.' ;", CONN)
                            drl = Querycount.ExecuteReader()
                            While drl.Read()
                                ln_count = drl(0).ToString
                            End While
                            If ln_count >= 1 Then
                                'lipa1.Items.Clear()
                                txtPante.Focus()
                            Else
                                MsgBox("Frente no Existe")
                                'Id_Frente.Text = ""
                                Id_Frente.Focus()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Ingrese numeros")
                        Id_Frente.Focus()
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        End If
    End Sub
    Private Sub valida_frente_tra()
        If Id_Frente.Text <> "0" Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim ln_count As Integer = Nothing
            Try
                If (Id_Frente.TextLength > 0) Then
                    Dim valor As Integer = Nothing
                    Try
                        valor = Convert.ToInt32(Id_Frente.Text)
                        If valor < 0 Then
                            MsgBox("ingrese numeros")
                        Else
                            CONN.Open()
                            Dim Querycount = New SqlCeCommand("SELECT COUNT(id_frente) FROM TB_FRENTES WHERE ID_FRENTE = " & valor & " AND abreviatura = 'TRAM.' ;", CONN)
                            drl = Querycount.ExecuteReader()
                            While drl.Read()
                                ln_count = drl(0).ToString
                            End While
                            If ln_count >= 1 Then
                                'lipa1.Items.Clear()
                                txtPante.Focus()
                            Else
                                MsgBox("Frente no Existe")
                                'Id_Frente.Text = ""
                                Id_Frente.Focus()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Ingrese numeros")
                        Id_Frente.Focus()
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        End If
    End Sub
    Private Sub valida_frente_gra()
        If Id_Frente.Text <> "0" Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim ln_count As Integer = Nothing
            Try
                If (Id_Frente.TextLength > 0) Then
                    Dim valor As Integer = Nothing
                    Try
                        valor = Convert.ToInt32(Id_Frente.Text)
                        If valor < 0 Then
                            MsgBox("ingrese numeros")
                        Else
                            CONN.Open()
                            Dim Querycount = New SqlCeCommand("SELECT COUNT(id_frente) FROM TB_FRENTES WHERE ID_FRENTE = " & valor & " AND abreviatura = 'GRA.' ;", CONN)
                            drl = Querycount.ExecuteReader()
                            While drl.Read()
                                ln_count = drl(0).ToString
                            End While
                            If ln_count >= 1 Then
                                'lipa1.Items.Clear()
                                txtPante.Focus()
                            Else
                                MsgBox("Frente no Existe")
                                'Id_Frente.Text = ""
                                Id_Frente.Focus()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Ingrese numeros")
                        Id_Frente.Focus()
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        End If
    End Sub
    Private Sub valida_frente_mal()
        If Id_Frente.Text <> "0" Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim ln_count As Integer = Nothing
            Try
                If (Id_Frente.TextLength > 0) Then
                    Dim valor As Integer = Nothing
                    Try
                        valor = Convert.ToInt32(Id_Frente.Text)
                        If valor < 0 Then
                            MsgBox("ingrese numeros")
                        Else
                            CONN.Open()
                            Dim Querycount = New SqlCeCommand("SELECT COUNT(id_frente) FROM TB_FRENTES WHERE ID_FRENTE = " & valor & " AND abreviatura = 'MAL.' ;", CONN)
                            drl = Querycount.ExecuteReader()
                            While drl.Read()
                                ln_count = drl(0).ToString
                            End While
                            If ln_count >= 1 Then
                                'lipa1.Items.Clear()
                                txtPante.Focus()
                            Else
                                MsgBox("Frente no Existe")
                                'Id_Frente.Text = ""
                                Id_Frente.Focus()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Ingrese numeros")
                        Id_Frente.Focus()
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        End If
    End Sub

    Private Sub Ho_des_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ho_des.LostFocus
        Dim valor As Integer = Nothing
        Dim otro As Integer = 0
        Try
            valor = Convert.ToInt32(Ho_des.Text)
            If valor >= 0 And valor <= 59 Then
                otro = Nothing
            ElseIf valor >= 100 And valor <= 159 Then
                otro = Nothing
            ElseIf valor >= 200 And valor <= 259 Then
                otro = Nothing
            ElseIf valor >= 300 And valor <= 359 Then
                otro = Nothing
            ElseIf valor >= 400 And valor <= 459 Then
                otro = Nothing
            ElseIf valor >= 500 And valor <= 559 Then
                otro = Nothing
            ElseIf valor >= 600 And valor <= 659 Then
                otro = Nothing
            ElseIf valor >= 700 And valor <= 759 Then
                otro = Nothing
            ElseIf valor >= 800 And valor <= 859 Then
                otro = Nothing
            ElseIf valor >= 900 And valor <= 959 Then
                otro = Nothing
            ElseIf valor >= 1000 And valor <= 1059 Then
                otro = Nothing
            ElseIf valor >= 1100 And valor <= 1159 Then
                otro = Nothing
            ElseIf valor >= 1200 And valor <= 1259 Then
                otro = Nothing
            ElseIf valor >= 1300 And valor <= 1359 Then
                otro = Nothing
            ElseIf valor >= 1400 And valor <= 1459 Then
                otro = Nothing
            ElseIf valor >= 1500 And valor <= 1559 Then
                otro = Nothing
            ElseIf valor >= 1600 And valor <= 1659 Then
                otro = Nothing
            ElseIf valor >= 1700 And valor <= 1759 Then
                otro = Nothing
            ElseIf valor >= 1800 And valor <= 1859 Then
                otro = Nothing
            ElseIf valor >= 1900 And valor <= 1959 Then
                otro = Nothing
            ElseIf valor >= 2000 And valor <= 2059 Then
                otro = Nothing
            ElseIf valor >= 2100 And valor <= 2159 Then
                otro = Nothing
            ElseIf valor >= 2200 And valor <= 2259 Then
                otro = Nothing
            ElseIf valor >= 2300 And valor <= 2359 Then
                otro = Nothing
            Else
                MsgBox("Ingrese Hora valida")
            End If
        Catch ex As Exception
            MsgBox("Ingrese Hora valida")
            Ho_des.Focus()
        End Try
    End Sub

    Private Sub grupo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grupo.LostFocus
        Dim valor As Integer = Nothing
        If tipot.Text = "T" Or tipot.Text = "U" Then
            Try
                valor = Convert.ToInt32(grupo.Text)
            Catch ex As Exception
                MsgBox("ingrese numeros")
                grupo.Text = "0"
            End Try
        End If
    End Sub

    Private Sub ruta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ruta.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(ruta.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                ruta.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            ruta.Focus()
            ruta.Text = "0"
        End Try
    End Sub
    Private Sub lipa1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lipa1.LostFocus
        lilo1.Items.Clear()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        Try
            If (Id_finca.Text.Length > 0) And (lipa1.Items.Item(lipa1.SelectedIndex).ToString.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim npante As Integer = Nothing
                Try
                    valor = Convert.ToInt32(Id_finca.Text)
                    npante = Convert.ToInt32(lipa1.Items.Item(lipa1.SelectedIndex))
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        nfinca = 0
                        npante = 0
                    Else
                        If tipot.Text <> "U" Then
                            npante = Convert.ToInt32(lipa1.Items.Item(lipa1.SelectedIndex))
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            If Empresa.Text.Trim = "1" Then
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            Else
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT');", CONN)
                            End If
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo1.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo1.Items.Add(0)
                            End If
                        ElseIf tipot.Text = "U" Then
                            npante = 1
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim nlote = Convert.ToInt32(lipa1.Items.Item(lipa1.SelectedIndex))
                            Dim QUERYl = New SqlCeCommand("SELECT id_variedad FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & "  and id_lote = " & nlote & " and estado = 'ACT' );", CONN)
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo1.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo1.Items.Add(0)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    'lipante.Focus()
                    Id_finca.Text = "0"
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por 5" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub lipa2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lipa2.LostFocus
        lilo2.Items.Clear()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        Try
            If (Id_finca.Text.Length > 0) And (lipa2.Items.Item(lipa2.SelectedIndex).ToString.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim npante As Integer = Nothing
                Try
                    valor = Convert.ToInt32(Id_finca.Text)
                    npante = Convert.ToInt32(lipa2.Items.Item(lipa2.SelectedIndex))
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        nfinca = 0
                        npante = 0
                    Else
                        If tipot.Text <> "U" Then
                            npante = Convert.ToInt32(lipa2.Items.Item(lipa2.SelectedIndex))
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' );", CONN)
                            If Empresa.Text.Trim = "1" Then
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            Else
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT');", CONN)
                            End If
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo2.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo2.Items.Add(0)
                            End If
                        ElseIf tipot.Text = "U" Then
                            npante = 1
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim nlote = Convert.ToInt32(lipa2.Items.Item(lipa2.SelectedIndex))
                            Dim QUERYl = New SqlCeCommand("SELECT id_variedad FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & "  and id_lote = " & nlote & " and estado = 'ACT' );", CONN)
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo2.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo2.Items.Add(0)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    'lipante.Focus()
                    'id_finca.Text = "0"
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por 6" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub lipa3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lipa3.LostFocus
        lilo3.Items.Clear()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        Try
            If (Id_finca.Text.Length > 0) And (lipa3.Items.Item(lipa3.SelectedIndex).ToString.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim npante As Integer = Nothing
                Try
                    valor = Convert.ToInt32(Id_finca.Text)
                    npante = Convert.ToInt32(lipa3.Items.Item(lipa3.SelectedIndex))
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        nfinca = 0
                        npante = 0
                    Else
                        If tipot.Text <> "U" Then
                            npante = Convert.ToInt32(lipa3.Items.Item(lipa3.SelectedIndex))
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' );", CONN)
                            If Empresa.Text.Trim = "1" Then
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            Else
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT');", CONN)
                            End If
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo3.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo3.Items.Add(0)
                            End If
                        ElseIf tipot.Text = "U" Then
                            npante = 1
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim nlote = Convert.ToInt32(lipa3.Items.Item(lipa3.SelectedIndex))
                            Dim QUERYl = New SqlCeCommand("SELECT id_variedad FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & "  and id_lote = " & nlote & " and estado = 'ACT' );", CONN)
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo3.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo3.Items.Add(0)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    'lipante.Focus()
                    'id_finca.Text = "0"
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por 7" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub lipa4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lipa4.LostFocus
        lilo4.Items.Clear()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        Try
            If (Id_finca.Text.Length > 0) And (lipa4.Items.Item(lipa4.SelectedIndex).ToString.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim npante As Integer = Nothing
                Try
                    valor = Convert.ToInt32(Id_finca.Text)
                    npante = Convert.ToInt32(lipa4.Items.Item(lipa4.SelectedIndex))
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        nfinca = 0
                        npante = 0
                    Else
                        If tipot.Text <> "U" Then
                            npante = Convert.ToInt32(lipa4.Items.Item(lipa4.SelectedIndex))
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' );", CONN)
                            If Empresa.Text.Trim = "1" Then
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            Else
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT');", CONN)
                            End If
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo4.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo4.Items.Add(0)
                            End If
                        ElseIf tipot.Text = "U" Then
                            npante = 1
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim nlote = Convert.ToInt32(lipa4.Items.Item(lipa4.SelectedIndex))
                            Dim QUERYl = New SqlCeCommand("SELECT id_variedad FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & "  and id_lote = " & nlote & " and estado = 'ACT' );", CONN)
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo4.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo4.Items.Add(0)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    'lipante.Focus()
                    'id_finca.Text = "0"
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por 8" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub
    Private Sub unidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles unidad.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(unidad.Text)
            If valor <= 0 Then
                MsgBox("ingrese numero")
                unidad.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numero")
            unidad.Focus()
            unidad.Text = "0"
        End Try
        f_valida_unidades()
    End Sub
    Private Sub f_valida_unidades()
        If (Trameado.Checked = True) Then
            If (Convert.ToInt32(unidad.Text) > 5) Then
                MsgBox("Tramos debe ser igual o menor a 5")
                unidad.Focus()
                unidad.Text = "0"
            End If
        ElseIf (Granel.Checked = True) Then
            If (Convert.ToInt32(unidad.Text) > 70) Then
                MsgBox("Excede limites de uñadas")
                unidad.Focus()
                unidad.Text = "0"
            End If
        End If
    End Sub

    Private Sub unidad2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles unidad2.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(unidad2.Text)
            If valor < 0 Then
                MsgBox("ingrese numero")
                unidad2.Text = "0"
            End If
        Catch ex As Exception
            MsgBox("ingrese numero")
            unidad2.Text = "0"
        End Try
    End Sub

    Private Sub unidad3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles unidad3.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(unidad3.Text)
            If valor < 0 Then
                MsgBox("ingrese numero")
                unidad3.Text = "0"
            End If
        Catch ex As Exception
            MsgBox("ingrese numero")
            unidad3.Text = "0"
        End Try
    End Sub

    Private Sub unidad4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles unidad4.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(unidad4.Text)
            If valor < 0 Then
                MsgBox("ingrese numero")
                unidad4.Text = "0"
            End If
        Catch ex As Exception
            MsgBox("ingrese numero")
            unidad4.Text = "0"
        End Try
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        fe_quema.Text = DateTimePicker1.Text.Substring(0, 8)
        Ho_quema.Text = DateTimePicker1.Text.Substring(8, 4)
    End Sub
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        quema2.Text = DateTimePicker2.Text.Substring(0, 8)
        hora2.Text = DateTimePicker2.Text.Substring(8, 4)
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        quema3.Text = DateTimePicker3.Text.Substring(0, 8)
        hora3.Text = DateTimePicker3.Text.Substring(8, 4)
    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged
        quema4.Text = DateTimePicker4.Text.Substring(0, 8)
        hora4.Text = DateTimePicker4.Text.Substring(8, 4)
    End Sub
    Private Sub Ho_quema_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ho_quema.LostFocus
        Dim valor As Integer = Nothing
        Dim otro As Integer = 0
        Try
            valor = Convert.ToInt32(Ho_quema.Text)
            If valor >= 0 And valor <= 59 Then
                otro = Nothing
            ElseIf valor >= 100 And valor <= 159 Then
                otro = Nothing
            ElseIf valor >= 200 And valor <= 259 Then
                otro = Nothing
            ElseIf valor >= 300 And valor <= 359 Then
                otro = Nothing
            ElseIf valor >= 400 And valor <= 459 Then
                otro = Nothing
            ElseIf valor >= 500 And valor <= 559 Then
                otro = Nothing
            ElseIf valor >= 600 And valor <= 659 Then
                otro = Nothing
            ElseIf valor >= 700 And valor <= 759 Then
                otro = Nothing
            ElseIf valor >= 800 And valor <= 859 Then
                otro = Nothing
            ElseIf valor >= 900 And valor <= 959 Then
                otro = Nothing
            ElseIf valor >= 1000 And valor <= 1059 Then
                otro = Nothing
            ElseIf valor >= 1100 And valor <= 1159 Then
                otro = Nothing
            ElseIf valor >= 1200 And valor <= 1259 Then
                otro = Nothing
            ElseIf valor >= 1300 And valor <= 1359 Then
                otro = Nothing
            ElseIf valor >= 1400 And valor <= 1459 Then
                otro = Nothing
            ElseIf valor >= 1500 And valor <= 1559 Then
                otro = Nothing
            ElseIf valor >= 1600 And valor <= 1659 Then
                otro = Nothing
            ElseIf valor >= 1700 And valor <= 1759 Then
                otro = Nothing
            ElseIf valor >= 1800 And valor <= 1859 Then
                otro = Nothing
            ElseIf valor >= 1900 And valor <= 1959 Then
                otro = Nothing
            ElseIf valor >= 2000 And valor <= 2059 Then
                otro = Nothing
            ElseIf valor >= 2100 And valor <= 2159 Then
                otro = Nothing
            ElseIf valor >= 2200 And valor <= 2259 Then
                otro = Nothing
            ElseIf valor >= 2300 And valor <= 2359 Then
                otro = Nothing
            Else
                MsgBox("Ingrese Hora valida")
                Ho_quema.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese Hora valida")
            Ho_quema.Focus()
        End Try
    End Sub
    Private Sub hora2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles hora2.LostFocus
        Dim valor As Integer = Nothing
        Dim otro As Integer = 0
        Try
            valor = Convert.ToInt32(hora2.Text)
            If valor >= 0 And valor <= 59 Then
                otro = Nothing
            ElseIf valor >= 100 And valor <= 159 Then
                otro = Nothing
            ElseIf valor >= 200 And valor <= 259 Then
                otro = Nothing
            ElseIf valor >= 300 And valor <= 359 Then
                otro = Nothing
            ElseIf valor >= 400 And valor <= 459 Then
                otro = Nothing
            ElseIf valor >= 500 And valor <= 559 Then
                otro = Nothing
            ElseIf valor >= 600 And valor <= 659 Then
                otro = Nothing
            ElseIf valor >= 700 And valor <= 759 Then
                otro = Nothing
            ElseIf valor >= 800 And valor <= 859 Then
                otro = Nothing
            ElseIf valor >= 900 And valor <= 959 Then
                otro = Nothing
            ElseIf valor >= 1000 And valor <= 1059 Then
                otro = Nothing
            ElseIf valor >= 1100 And valor <= 1159 Then
                otro = Nothing
            ElseIf valor >= 1200 And valor <= 1259 Then
                otro = Nothing
            ElseIf valor >= 1300 And valor <= 1359 Then
                otro = Nothing
            ElseIf valor >= 1400 And valor <= 1459 Then
                otro = Nothing
            ElseIf valor >= 1500 And valor <= 1559 Then
                otro = Nothing
            ElseIf valor >= 1600 And valor <= 1659 Then
                otro = Nothing
            ElseIf valor >= 1700 And valor <= 1759 Then
                otro = Nothing
            ElseIf valor >= 1800 And valor <= 1859 Then
                otro = Nothing
            ElseIf valor >= 1900 And valor <= 1959 Then
                otro = Nothing
            ElseIf valor >= 2000 And valor <= 2059 Then
                otro = Nothing
            ElseIf valor >= 2100 And valor <= 2159 Then
                otro = Nothing
            ElseIf valor >= 2200 And valor <= 2259 Then
                otro = Nothing
            ElseIf valor >= 2300 And valor <= 2359 Then
                otro = Nothing
            Else
                MsgBox("Ingrese Hora valida")
                hora2.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese Hora valida")
            hora2.Focus()
        End Try
    End Sub

    Private Sub hora3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles hora3.LostFocus
        Dim valor As Integer = Nothing
        Dim otro As Integer = 0
        Try
            valor = Convert.ToInt32(hora3.Text)
            If valor >= 0 And valor <= 59 Then
                otro = Nothing
            ElseIf valor >= 100 And valor <= 159 Then
                otro = Nothing
            ElseIf valor >= 200 And valor <= 259 Then
                otro = Nothing
            ElseIf valor >= 300 And valor <= 359 Then
                otro = Nothing
            ElseIf valor >= 400 And valor <= 459 Then
                otro = Nothing
            ElseIf valor >= 500 And valor <= 559 Then
                otro = Nothing
            ElseIf valor >= 600 And valor <= 659 Then
                otro = Nothing
            ElseIf valor >= 700 And valor <= 759 Then
                otro = Nothing
            ElseIf valor >= 800 And valor <= 859 Then
                otro = Nothing
            ElseIf valor >= 900 And valor <= 959 Then
                otro = Nothing
            ElseIf valor >= 1000 And valor <= 1059 Then
                otro = Nothing
            ElseIf valor >= 1100 And valor <= 1159 Then
                otro = Nothing
            ElseIf valor >= 1200 And valor <= 1259 Then
                otro = Nothing
            ElseIf valor >= 1300 And valor <= 1359 Then
                otro = Nothing
            ElseIf valor >= 1400 And valor <= 1459 Then
                otro = Nothing
            ElseIf valor >= 1500 And valor <= 1559 Then
                otro = Nothing
            ElseIf valor >= 1600 And valor <= 1659 Then
                otro = Nothing
            ElseIf valor >= 1700 And valor <= 1759 Then
                otro = Nothing
            ElseIf valor >= 1800 And valor <= 1859 Then
                otro = Nothing
            ElseIf valor >= 1900 And valor <= 1959 Then
                otro = Nothing
            ElseIf valor >= 2000 And valor <= 2059 Then
                otro = Nothing
            ElseIf valor >= 2100 And valor <= 2159 Then
                otro = Nothing
            ElseIf valor >= 2200 And valor <= 2259 Then
                otro = Nothing
            ElseIf valor >= 2300 And valor <= 2359 Then
                otro = Nothing
            Else
                MsgBox("Ingrese Hora valida")
                hora3.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese Hora valida")
            hora3.Focus()
        End Try
    End Sub

    Private Sub hora4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles hora4.LostFocus
        Dim valor As Integer = Nothing
        Dim otro As Integer = 0
        Try
            valor = Convert.ToInt32(hora4.Text)
            If valor >= 0 And valor <= 59 Then
                otro = Nothing
            ElseIf valor >= 100 And valor <= 159 Then
                otro = Nothing
            ElseIf valor >= 200 And valor <= 259 Then
                otro = Nothing
            ElseIf valor >= 300 And valor <= 359 Then
                otro = Nothing
            ElseIf valor >= 400 And valor <= 459 Then
                otro = Nothing
            ElseIf valor >= 500 And valor <= 559 Then
                otro = Nothing
            ElseIf valor >= 600 And valor <= 659 Then
                otro = Nothing
            ElseIf valor >= 700 And valor <= 759 Then
                otro = Nothing
            ElseIf valor >= 800 And valor <= 859 Then
                otro = Nothing
            ElseIf valor >= 900 And valor <= 959 Then
                otro = Nothing
            ElseIf valor >= 1000 And valor <= 1059 Then
                otro = Nothing
            ElseIf valor >= 1100 And valor <= 1159 Then
                otro = Nothing
            ElseIf valor >= 1200 And valor <= 1259 Then
                otro = Nothing
            ElseIf valor >= 1300 And valor <= 1359 Then
                otro = Nothing
            ElseIf valor >= 1400 And valor <= 1459 Then
                otro = Nothing
            ElseIf valor >= 1500 And valor <= 1559 Then
                otro = Nothing
            ElseIf valor >= 1600 And valor <= 1659 Then
                otro = Nothing
            ElseIf valor >= 1700 And valor <= 1759 Then
                otro = Nothing
            ElseIf valor >= 1800 And valor <= 1859 Then
                otro = Nothing
            ElseIf valor >= 1900 And valor <= 1959 Then
                otro = Nothing
            ElseIf valor >= 2000 And valor <= 2059 Then
                otro = Nothing
            ElseIf valor >= 2100 And valor <= 2159 Then
                otro = Nothing
            ElseIf valor >= 2200 And valor <= 2259 Then
                otro = Nothing
            ElseIf valor >= 2300 And valor <= 2359 Then
                otro = Nothing
            Else
                MsgBox("Ingrese Hora valida")
                hora4.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese Hora valida")
            hora4.Focus()
        End Try
    End Sub
    Private Sub zona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles zona.LostFocus
        If ((tipot.Text <> "V") And (tipot.Text <> "U")) Then
            Dim valor As Integer = Nothing
            Try
                valor = Convert.ToInt32(zona.Text)
                If (valor <= 0) Or (valor > 2) Then
                    MsgBox("ingrese numeros VALIDOS 1 o 2")
                    zona.Focus()
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                zona.Focus()
            End Try
        End If
    End Sub
    Private Sub fecturnop_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fecturnop.ValueChanged
        fecturno.Text = fecturnop.Text.Substring(0, 12)
        'Ho_quema.Text = DateTimePicker1.Text.Substring(8, 4)
    End Sub

    Private Sub Establecer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Establecer.Click
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim QUERY = New SqlCeCommand("UPDATE TB_PARAMETROS SET  fecha_turno ='" & Convert.ToDateTime(fecturno.Text.Substring(2, 2) + "-" + fecturno.Text.Substring(0, 2) + "-" + fecturno.Text.Substring(4, 4)) & "', ID_ZONA = '" + Lizona.Items.Item(Lizona.SelectedIndex()) + "', TIPO_CANIA = '" + presentanew.text + "';", CONN)
        'Dim dr As SqlCeDataReader = Nothing
        Dim REGISTROS As Integer
        Try
            CONN.Open()
            If CONN.State = Data.ConnectionState.Open Then
                REGISTROS = QUERY.ExecuteNonQuery
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por 9" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub Manual_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manual.CheckStateChanged
        If Manual.CheckState = Windows.Forms.CheckState.Checked Then
            Nboleta.Enabled = True
            scanner.Visible = False
            Lscanner.Visible = False
            Button1.Visible = True
            If tipot.Text = "L" Or tipot.Text = "T" Then
                txtPLaca.Visible = True
            Else
                txtPLaca.Visible = False
            End If
        ElseIf Manual.CheckState = Windows.Forms.CheckState.Unchecked Then
            scanner.Visible = True
            Lscanner.Visible = True
            Nboleta.Enabled = False
            txtPLaca.Visible = False
        Else
            scanner.Visible = True
            Lscanner.Visible = True
        End If

        '9900
        If tipot.Text = "T" Then
            plata.Visible = False
            cole.Visible = False
            Nboleta.Visible = False
            Label39.Visible = False
            Label25.Visible = False
            Label26.Visible = False

            Nboleta.Text = "0"
            plata.Text = "0"
            cole.Text = "0"
        Else
            plata.Visible = True
            cole.Visible = True
            Nboleta.Visible = True
            Label39.Visible = True
            Label25.Visible = True
            Label26.Visible = True
        End If

    End Sub
    Private Sub scanner_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles scanner.LostFocus
        f_valida_lectura()
        ''f_lee_scanner()
        'f_lee_scanner_v2()
    End Sub
    Private Sub f_lee_scanner_v2()
        Dim valor As Decimal = Nothing
        'Dim valor2 As Decimal = Nothing
        Try
            valor = Convert.ToDecimal(scanner.Text)
            'valor = Convert.ToInt64(scanner.Text)
            Dim t As String
            Dim v As String
            Dim p As String
            Dim pi As String
            Dim ru As String
            Dim ma As String
            Dim co As String
            Dim bt As String
            If scanner.Text.Length > 12 Then
                p = scanner.Text.Substring(0, 3) 'periodo'
                t = scanner.Text.Substring(4, 4) 'transportista'
                v = scanner.Text.Substring(9, 3) 'vehiculo'
                pi = scanner.Text.Substring(13, 3) 'piloto'
                If scanner.Text.Length > 19 Then
                    ru = Convert.ToInt32(scanner.Text.Substring(17, 3)) 'ruta'
                    id_ruta.Text = ru.ToString.Trim
                End If
                trans.Text = t.Replace("0", " ").TrimStart.Replace(" ", "0")
                peri.Text = p.Replace("0", " ").TrimStart.Replace(" ", "0")
                vehi.Text = v.Replace("0", " ").TrimStart.Replace(" ", "0")
                pilo.Text = pi.Replace("0", " ").TrimStart.Replace(" ", "0")
                ' trans.Text = trans.Text.Replace(" ", "0").TrimStart.Replace(" ", "0")
                If scanner.Text.Length > 36 Then
                    ma = scanner.Text.Substring(21, 3) 'plataforma
                    co = scanner.Text.Substring(25, 3) 'colera
                    bt = scanner.Text.Substring(29, 8) 'boleta transporte
                    plata.Text = ma.Replace("0", " ").TrimStart.Replace(" ", "0")
                    cole.Text = co.Replace("0", " ").TrimStart.Replace(" ", "0")
                    Nboleta.Text = bt.Replace("0", " ").TrimStart.Replace(" ", "0")
                End If

                ruta.Text = id_ruta.Text
                id_transportista.Text = trans.Text
                id_vehiculo.Text = vehi.Text
                Id_piloto.Text = pilo.Text
                carga_transporte()
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    If id_ruta.TextLength > 0 Then
                        Dim numero As Integer
                        Try
                            numero = Convert.ToInt32(id_ruta.Text.Trim)
                            If (((numero > 0) And (numero < 7)) Or ((numero > 9) And (numero < 40))) Then
                                If tipot.Text = "M" Or tipot.Text = "L" Or tipot.Text = "T" Then
                                    carga_envio()
                                    coleccion.TabPages.Item(5).BringToFront()
                                    coleccion.SelectedIndex = 5
                                Else
                                    coleccion.TabPages.Item(4).BringToFront()
                                    coleccion.SelectedIndex = 4
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("Ingrese numeros")
                            id_ruta.Focus()
                        End Try
                    End If
                Else
                    coleccion.TabPages.Item(4).BringToFront()
                    coleccion.SelectedIndex = 4

                End If
            Else
                MsgBox("No paso")
            End If
            If valor < 0 Then
                MsgBox("ingrese numeros")
                scanner.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            scanner.Focus()
        End Try
    End Sub
    Private Sub f_lee_scanner()
        Dim valor As Decimal = Nothing
        Dim v_valor As Integer
        'Dim valor2 As Decimal = Nothing
        Try
            'valor = Convert.ToDecimal(scanner.Text)
            'valor = Convert.ToInt64(scanner.Text)
            Dim t As String
            Dim v As String
            Dim p As String
            Dim pi As String
            Dim ru As String
            Dim ma As String
            Dim co As String
            Dim bt As String
            Dim empresa As String
            Dim v_placa As String
            Dim fecha_c As DateTime
            Dim fecha_sis As DateTime
            Dim fecha_tem As String
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing

            If tipot.Text = "L" Then
                '------------------------------------------------------------
                If Sticker.CheckState = Windows.Forms.CheckState.Unchecked Then
                    Dim v_clave_uno As String
                    Dim v_clave_dos As String
                    Dim v_clave_tres As String
                    Dim v_clave_cuatro As String
                    'Dim v_placa As String

                    v_clave_uno = scanner.Text.Substring(8, 1)
                    v_clave_dos = scanner.Text.Substring(9, 1)
                    v_clave_tres = scanner.Text.Substring(10, 1)
                    v_clave_cuatro = scanner.Text.Substring(11, 1)
                    empresa = scanner.Text.Substring(8, 4)

                    p_placa = scanner.Text.Substring(2, 6)
                    '--------------------------------------------------------------
                    Button1.Visible = True
                    v_placa = scanner.Text.Substring(2, 6)
                    ' t = scanner.Text.Substring(0, 3) 'tranporstista
                    'v = scanner.Text.Substring(3, 3) 'vehiculo
                    'p = 11
                    p = 10
                    empresa = scanner.Text.Substring(8, 4) 'empresa

                    If empresa = "EPSA" Then
                        Nboleta.Text = "01"
                        'trans.Text = t.Replace("0", " ").TrimStart.Replace(" ", "0")
                        'peri.Text = p.Replace("0", " ").TrimStart.Replace(" ", "0")
                        'vehi.Text = v.Replace("0", " ").TrimStart.Replace(" ", "0")
                    Else
                        MsgBox("El codigo no corresponde al PILAR")
                        scanner.Focus()
                    End If
                    '------------------------------------------------------------
                    Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    CONN.Open()
                    Dim QueryEnv = New SqlCeCommand("Select count(envio) FROM TB_ENVIOS WHERE (PLACAS = '" + p_placa + "');", CONN)
                    drl = QueryEnv.ExecuteReader()
                    While drl.Read()
                        v_valor = drl(0).ToString
                    End While
                    If v_valor > 0 Then
                        '---------------------------------
                        Dim vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                        'Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where transportista =" & Convert.ToInt32(t) & " AND vehiculo = " + v + ";", vr_CONN)
                        vr_CONN.Open()
                        Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where placas = '" + p_placa + "';", vr_CONN)
                        Dim vr_dr As SqlCeDataReader = Nothing
                        Dim vr_dr2 As SqlCeDataReader = Nothing

                        vr_dr = vr_QUERY.ExecuteReader
                        While vr_dr.Read
                            fecha_c = vr_dr(0)
                            'If fecha_c > Now.ToString("yyyyMMdd HH:mm") Then
                            fecha_tem = Now.ToString("dd/MM/yyyy HH:mm")
                            fecha_tem = DateTime.Now
                            ' fecha_sis = Now.ToString("dd/MM/yyyy HH:mm") ' Now.ToString("ddMMyyyyHHmmss")
                            If fecha_c > DateTime.Now Then ''Now.ToString("dd/MM/yyyy HH:mm:ss") Then
                                'Now.ToString("ddMMyyyyHHmm")
                                '13/03/2018 05:26:00
                                '15/03/2018 11:24
                                MsgBox("No tiene media hora de leido el envio")
                                scanner.Focus()
                            End If
                        End While
                        vr_CONN.Close()
                        '---------------------------------
                    End If
                    '------------------------------------------------------------
                    If scanner.Text.Length > 12 Then
                        p = scanner.Text.Substring(0, 3) 'periodo'
                        t = scanner.Text.Substring(4, 4) 'transportista'
                        v = scanner.Text.Substring(9, 3) 'vehiculo'
                        pi = scanner.Text.Substring(13, 3) 'piloto'
                        If scanner.Text.Length > 19 Then
                            ru = Convert.ToInt32(scanner.Text.Substring(17, 3)) 'ruta'
                            id_ruta.Text = ru.ToString.Trim
                        End If
                        trans.Text = t.Replace("0", " ").TrimStart.Replace(" ", "0")
                        peri.Text = p.Replace("0", " ").TrimStart.Replace(" ", "0")
                        vehi.Text = v.Replace("0", " ").TrimStart.Replace(" ", "0")
                        pilo.Text = pi.Replace("0", " ").TrimStart.Replace(" ", "0")
                        ' trans.Text = trans.Text.Replace(" ", "0").TrimStart.Replace(" ", "0")
                        If scanner.Text.Length > 36 Then
                            ma = scanner.Text.Substring(21, 3) 'plataforma
                            co = scanner.Text.Substring(25, 3) 'colera
                            bt = scanner.Text.Substring(29, 8) 'boleta transporte
                            plata.Text = ma.Replace("0", " ").TrimStart.Replace(" ", "0")
                            cole.Text = co.Replace("0", " ").TrimStart.Replace(" ", "0")
                            Nboleta.Text = bt.Replace("0", " ").TrimStart.Replace(" ", "0")
                        End If

                        ruta.Text = id_ruta.Text
                        id_transportista.Text = trans.Text
                        id_vehiculo.Text = vehi.Text
                        Id_piloto.Text = pilo.Text
                        carga_transporte()
                        If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                            If id_ruta.TextLength > 0 Then
                                Dim numero As Integer
                                Try
                                    numero = Convert.ToInt32(id_ruta.Text.Trim)
                                    If (((numero > 0) And (numero < 7)) Or ((numero > 9) And (numero < 40))) Then
                                        If tipot.Text = "M" Or tipot.Text = "L" Or tipot.Text = "T" Then
                                            carga_envio()
                                            coleccion.TabPages.Item(5).BringToFront()
                                            coleccion.SelectedIndex = 5
                                        Else
                                            coleccion.TabPages.Item(4).BringToFront()
                                            coleccion.SelectedIndex = 4
                                        End If
                                    End If
                                Catch ex As Exception
                                    MsgBox("Ingrese numeros")
                                    'id_ruta.Focus()
                                End Try
                            End If
                        Else
                            coleccion.TabPages.Item(4).BringToFront()
                            coleccion.SelectedIndex = 4

                        End If
                    Else
                        MsgBox("No paso")
                    End If
                End If
            ElseIf tipot.Text = "T" Then
                '------------------------------------------------------------
                Dim v_clave_uno As String
                Dim v_clave_dos As String
                Dim v_clave_tres As String
                Dim v_clave_cuatro As String
                'Dim v_placa As String

                v_clave_uno = scanner.Text.Substring(8, 1)
                v_clave_dos = scanner.Text.Substring(9, 1)
                v_clave_tres = scanner.Text.Substring(10, 1)
                v_clave_cuatro = scanner.Text.Substring(11, 1)
                empresa = scanner.Text.Substring(8, 4)

                p_placa = scanner.Text.Substring(2, 6)
                '--------------------------------------------------------------
                Button1.Visible = True
                v_placa = scanner.Text.Substring(2, 6)
                ' t = scanner.Text.Substring(0, 3) 'tranporstista
                'v = scanner.Text.Substring(3, 3) 'vehiculo
                'p = 11
                p = 10
                empresa = scanner.Text.Substring(8, 4) 'empresa

                If empresa = "EPSA" Then
                    Nboleta.Text = "01"
                    'trans.Text = t.Replace("0", " ").TrimStart.Replace(" ", "0")
                    'peri.Text = p.Replace("0", " ").TrimStart.Replace(" ", "0")
                    'vehi.Text = v.Replace("0", " ").TrimStart.Replace(" ", "0")
                Else
                    MsgBox("El codigo no corresponde al PILAR")
                    scanner.Focus()
                End If
                '------------------------------------------------------------
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                CONN.Open()
                Dim QueryEnv = New SqlCeCommand("Select count(envio) FROM TB_ENVIOS WHERE (PLACAS = '" + p_placa + "');", CONN)
                drl = QueryEnv.ExecuteReader()
                While drl.Read()
                    v_valor = drl(0).ToString
                End While
                If v_valor > 0 Then
                    '---------------------------------
                    Dim vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    'Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where transportista =" & Convert.ToInt32(t) & " AND vehiculo = " + v + ";", vr_CONN)
                    vr_CONN.Open()
                    Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where placas = '" + p_placa + "';", vr_CONN)
                    Dim vr_dr As SqlCeDataReader = Nothing
                    Dim vr_dr2 As SqlCeDataReader = Nothing

                    vr_dr = vr_QUERY.ExecuteReader
                    While vr_dr.Read
                        fecha_c = vr_dr(0)
                        'If fecha_c > Now.ToString("yyyyMMdd HH:mm") Then
                        fecha_tem = Now.ToString("dd/MM/yyyy HH:mm")
                        fecha_tem = DateTime.Now
                        ' fecha_sis = Now.ToString("dd/MM/yyyy HH:mm") ' Now.ToString("ddMMyyyyHHmmss")
                        If fecha_c > DateTime.Now Then ''Now.ToString("dd/MM/yyyy HH:mm:ss") Then
                            'Now.ToString("ddMMyyyyHHmm")
                            '13/03/2018 05:26:00
                            '15/03/2018 11:24
                            MsgBox("No tiene media hora de leido el envio")
                            scanner.Focus()
                        End If
                    End While
                    vr_CONN.Close()
                    '---------------------------------
                End If
                '------------------------------------------------------------
            ElseIf tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "M" Then
                If scanner.Text.Length > 12 Then
                    p = scanner.Text.Substring(0, 3) 'periodo'
                    t = scanner.Text.Substring(4, 4) 'transportista'
                    v = scanner.Text.Substring(9, 3) 'vehiculo'
                    pi = scanner.Text.Substring(13, 3) 'piloto'
                    If scanner.Text.Length > 19 Then
                        ru = Convert.ToInt32(scanner.Text.Substring(17, 3)) 'ruta'
                        id_ruta.Text = ru.ToString.Trim
                    End If
                    trans.Text = t.Replace("0", " ").TrimStart.Replace(" ", "0")
                    peri.Text = p.Replace("0", " ").TrimStart.Replace(" ", "0")
                    vehi.Text = v.Replace("0", " ").TrimStart.Replace(" ", "0")
                    pilo.Text = pi.Replace("0", " ").TrimStart.Replace(" ", "0")
                    ' trans.Text = trans.Text.Replace(" ", "0").TrimStart.Replace(" ", "0")
                    If scanner.Text.Length > 36 Then
                        ma = scanner.Text.Substring(21, 3) 'plataforma
                        co = scanner.Text.Substring(25, 3) 'colera
                        bt = scanner.Text.Substring(29, 8) 'boleta transporte
                        plata.Text = ma.Replace("0", " ").TrimStart.Replace(" ", "0")
                        cole.Text = co.Replace("0", " ").TrimStart.Replace(" ", "0")
                        Nboleta.Text = bt.Replace("0", " ").TrimStart.Replace(" ", "0")
                    End If

                    ruta.Text = id_ruta.Text
                    id_transportista.Text = trans.Text
                    id_vehiculo.Text = vehi.Text
                    Id_piloto.Text = pilo.Text
                    carga_transporte()
                    If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                        If id_ruta.TextLength > 0 Then
                            Dim numero As Integer
                            Try
                                numero = Convert.ToInt32(id_ruta.Text.Trim)
                                If (((numero > 0) And (numero < 7)) Or ((numero > 9) And (numero < 40))) Then
                                    If tipot.Text = "M" Or tipot.Text = "L" Or tipot.Text = "T" Then
                                        carga_envio()
                                        coleccion.TabPages.Item(5).BringToFront()
                                        coleccion.SelectedIndex = 5
                                    Else
                                        coleccion.TabPages.Item(4).BringToFront()
                                        coleccion.SelectedIndex = 4
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("Ingrese numeros")
                                'id_ruta.Focus()
                            End Try
                        End If
                    Else
                        coleccion.TabPages.Item(4).BringToFront()
                        coleccion.SelectedIndex = 4

                    End If
                Else
                    MsgBox("No paso")
                End If

            End If

            '            If valor < 0 Then
            'MsgBox("ingrese numeros")
            'scanner.Focus()
            'End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            'scanner.Focus()
        End Try
    End Sub
    Private Sub f_valida_lectura()
        If (tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "M") Then      'valida si fuera granel, colera y meca
            Dim pregunta As Integer
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim dato_scanner As String = Nothing
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            Try
                If (scanner.Text.Length > 0) Then
                    '----------------omitir comas-----------
                    dato_scanner = scanner.Text.Substring(29, 8)
                    '---------------------------------------
                    Dim valor As Integer = Nothing
                    Dim valor_scanner As Integer = Nothing
                    Try
                        valor_scanner = Convert.ToInt32(dato_scanner)
                        If valor_scanner < 0 Then
                            MsgBox("Ingrese boleta correcta")
                            scanner.Text = ""
                            scanner.Focus()
                        Else
                            CONN.Open()
                            Dim QueryPant = New SqlCeCommand("Select count(boleta_transporte) FROM TB_ENVIOS WHERE (BOLETA_TRANSPORTE = " & valor_scanner & ");", CONN)
                            drl = QueryPant.ExecuteReader()
                            While drl.Read()
                                valor = drl(0).ToString
                            End While
                            If valor > 0 Then
                                MsgBox("Boleta ya fue scaneada <<Reportarlo>>")
                                pregunta = MsgBox("Esta seguro que quiere continuar?", MsgBoxStyle.YesNo)
                                If pregunta = vbYes Then
                                    'f_lee_scanner()
                                    f_lee_scanner_v2()
                                Else
                                    scanner.Text = ""
                                    scanner.Focus()
                                End If
                                'scanner.Focus()
                                'scanner.Text = ""
                            Else
                                f_lee_scanner_v2()
                                'f_lee_scanner()
                                '' Nboleta.Focus()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Error Boleta Transporte" & ex.Message & vbCrLf & "Favor Reportarlo.")
                        scanner.Focus()
                        scanner.Text = ""
                    End Try
                End If
            Catch ex As Exception
                MsgBox("Error Boleta Transporte " & ex.Message & vbCrLf & "Favor Reportarlo.")
            End Try
            CONN.Close()
            '---------------------------------------------------------------------------fin valida granel, colera y meca
        ElseIf tipot.Text = "T" Then
            Nboleta.Visible = False
            f_valida_sticker_tramero()
            Nboleta.Text = ""
            '------------------------------fin end if;
        ElseIf tipot.Text = "L" Then
            If (v_sticket = 1) Then
                f_lee_scanner_v2()
            Else
                f_valida_sticker_tramero()
            End If
            'f_valida_sticker_tramero()
        End If
    End Sub
    Private Sub f_valida_sticker_tramero()
        Dim valor As Decimal = Nothing
        Dim v_valor As Integer

        Dim empresa As String
        Dim v_placa As String
        Dim p As String
        Dim fecha_c As DateTime
        Dim fecha_tem As String

        Dim v_clave_uno As String
        Dim v_clave_dos As String
        Dim v_clave_tres As String
        Dim v_clave_cuatro As String

        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        'Dim v_placa As String

        v_clave_uno = scanner.Text.Substring(8, 1)
        v_clave_dos = scanner.Text.Substring(9, 1)
        v_clave_tres = scanner.Text.Substring(10, 1)
        v_clave_cuatro = scanner.Text.Substring(11, 1)
        Empresa = scanner.Text.Substring(8, 4)

        p_placa = scanner.Text.Substring(2, 6)
        '--------------------------------------------------------------
        Button1.Visible = True
        v_placa = scanner.Text.Substring(2, 6)
        ' t = scanner.Text.Substring(0, 3) 'tranporstista
        'v = scanner.Text.Substring(3, 3) 'vehiculo
        'p = 11
        p = 10
        Empresa = scanner.Text.Substring(8, 4) 'empresa

        If Empresa = "EPSA" Then
            Nboleta.Text = "01"
            'trans.Text = t.Replace("0", " ").TrimStart.Replace(" ", "0")
            'peri.Text = p.Replace("0", " ").TrimStart.Replace(" ", "0")
            'vehi.Text = v.Replace("0", " ").TrimStart.Replace(" ", "0")
        Else
            MsgBox("El codigo no corresponde al PILAR")
            scanner.Focus()
        End If
        '------------------------------------------------------------
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        CONN.Open()
        Dim QueryEnv = New SqlCeCommand("Select count(envio) FROM TB_ENVIOS WHERE (PLACAS = '" + p_placa + "');", CONN)
        drl = QueryEnv.ExecuteReader()
        While drl.Read()
            v_valor = drl(0).ToString
        End While
        If v_valor > 0 Then
            '---------------------------------
            Dim vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            'Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where transportista =" & Convert.ToInt32(t) & " AND vehiculo = " + v + ";", vr_CONN)
            vr_CONN.Open()
            Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where placas = '" + p_placa + "';", vr_CONN)
            Dim vr_dr As SqlCeDataReader = Nothing
            Dim vr_dr2 As SqlCeDataReader = Nothing

            vr_dr = vr_QUERY.ExecuteReader
            While vr_dr.Read
                fecha_c = vr_dr(0)
                'If fecha_c > Now.ToString("yyyyMMdd HH:mm") Then
                fecha_tem = Now.ToString("dd/MM/yyyy HH:mm")
                fecha_tem = DateTime.Now
                ' fecha_sis = Now.ToString("dd/MM/yyyy HH:mm") ' Now.ToString("ddMMyyyyHHmmss")
                If fecha_c > DateTime.Now Then ''Now.ToString("dd/MM/yyyy HH:mm:ss") Then
                    'Now.ToString("ddMMyyyyHHmm")
                    '13/03/2018 05:26:00
                    '15/03/2018 11:24
                    MsgBox("No tiene media hora de leido el envio")
                    scanner.Focus()
                End If
            End While
            vr_CONN.Close()
            '---------------------------------
        End If
    End Sub
    Private Sub f_valida_lectura_manual()
        Dim pregunta As Integer
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim dato_scanner As String = Nothing
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Try
            If (Nboleta.Text.Length > 0) Then
                '----------------omitir comas-----------
                dato_scanner = Nboleta.Text
                '---------------------------------------
                Dim valor As Integer = Nothing
                Dim valor_scanner As Integer = Nothing
                Try
                    valor_scanner = Convert.ToInt32(dato_scanner)
                    If valor_scanner < 0 Then
                        MsgBox("Ingrese boleta correcta")
                        Nboleta.Text = ""
                        Nboleta.Focus()
                    Else
                        CONN.Open()
                        Dim QueryPant = New SqlCeCommand("Select count(boleta_transporte) FROM TB_ENVIOS WHERE (BOLETA_TRANSPORTE = " & valor_scanner & ");", CONN)
                        drl = QueryPant.ExecuteReader()
                        While drl.Read()
                            valor = drl(0).ToString
                        End While
                        If valor > 0 Then
                            MsgBox("Boleta ya fue scaneada <<Reportarlo>>")
                            pregunta = MsgBox("Esta seguro que quiere continuar?", MsgBoxStyle.YesNo)
                            If pregunta = vbYes Then
                                peri.Focus()
                            Else
                                Nboleta.Text = ""
                                Nboleta.Focus()
                            End If
                            'scanner.Focus()
                            'scanner.Text = ""
                        Else
                            peri.Focus()
                            'scanner.Text = ""
                            ' Nboleta.Focus()
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error Boleta Transporte" & ex.Message & vbCrLf & "Favor Reportarlo.")
                    Nboleta.Focus()
                    Nboleta.Text = ""
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error Boleta Transporte " & ex.Message & vbCrLf & "Favor Reportarlo.")
        End Try
        CONN.Close()
    End Sub
    Private Sub peri_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles peri.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(peri.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                peri.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            peri.Focus()
            peri.Text = "0"
        End Try
    End Sub

    Private Sub pilo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles pilo.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(pilo.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                pilo.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            pilo.Focus()
            pilo.Text = "0"
        End Try
    End Sub

    Private Sub trans_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles trans.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(trans.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                trans.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            trans.Focus()
            trans.Text = "0"
        End Try
    End Sub

    Private Sub vehi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles vehi.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(vehi.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                vehi.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            vehi.Focus()
            vehi.Text = "0"
        End Try
    End Sub
    Private Sub lectura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'EnviosDataSet.TB_CROQUIS' Puede moverla o quitarla según sea necesario.
        'Me.TB_CROQUISTableAdapter.Fill(Me.EnviosDataSet.TB_CROQUIS)
        'TODO: esta línea de código carga datos en la tabla 'Frentes.TB_FRENTES' Puede moverla o quitarla según sea necesario.
        '
        'Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        'Try
        'If id_transportista.Text.Length > 0 Then
        ' CONN.Open()
        'Me.TB_FRENTESTableAdapter.Fill(Me.Frentes.TB_FRENTES)
        'Catch ex As Exception
        'MsgBox("Error ocasionado por 10" & ex.Message & vbCrLf & _
        '        "Favor de reportarlo.")
        'End Try
        'CONN.Close()

        'Me.TB_FRENTESTableAdapter.Fill(Me.Frentes.TB_FRENTES)

        'Me.TB_FRENTESTableAdapter.Fill(Me.Frentes.TB_FRENTES)
        ' numero_reporte()
        If ((Empresa.Text = "6326") Or (Empresa.Text = "6327")) Then
            LRUTA.Visible = False
            id_ruta.Visible = False
        End If
        updateDataHandler = New EventHandler(AddressOf UpdateData)
        AddHandler gps.DeviceStateChanged, New DeviceStateChangedEventHandler(AddressOf gps_DeviceStateChanged)
        AddHandler gps.LocationChanged, New LocationChangedEventHandler(AddressOf gps_LocationChanged)
        'If Not gps.Opened Then gps.Open()
    End Sub
    Private Sub Id_ticket_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Id_ticket.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(Id_ticket.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            Id_ticket.Text = "0"
        End Try
    End Sub
    Private Sub id_transportista_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles id_transportista.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(id_transportista.Text)
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim QUERY = New SqlCeCommand("SELECT DESCRIPCION FROM TB_TRANSPORTISTAS WHERE ID_TRANSPORTISTA = " & Convert.ToInt32(id_transportista.Text.Trim) & ";", CONN)
            Dim dr As SqlCeDataReader = Nothing
            Try
                If id_transportista.Text.Length > 0 Then
                    CONN.Open()
                    dr = QUERY.ExecuteReader()
                    While dr.Read()
                        Nombre_transportista.Text = dr(0).ToString
                    End While
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por 11" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
            If valor < 0 Then
                MsgBox("ingrese numeros")
                id_transportista.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            id_transportista.Focus()
            id_transportista.Text = "0"
        End Try
    End Sub
    Private Sub id_vehiculo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles id_vehiculo.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(id_vehiculo.Text)
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim QUERY = New SqlCeCommand("select b.tipo_placa+'-'+b.numero_placa from TB_VEHICULOS_TRANSPORTISTA a, TB_VEHICULOS b where b.id_vehiculo = a.id_vehiculo_original and a.id_vehiculo = " & Convert.ToInt32(id_vehiculo.Text.Trim) & " and a.id_transportista =" & Convert.ToInt32(id_transportista.Text.Trim) & " AND A.ESTADO = 'ACT';", CONN)
            Dim dr As SqlCeDataReader = Nothing
            Try
                If id_vehiculo.Text.Length > 0 Then
                    CONN.Open()
                    dr = QUERY.ExecuteReader()
                    While dr.Read()
                        Placa.Text = dr(0).ToString
                    End While
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por 12" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
            If valor < 0 Then
                MsgBox("ingrese numeros")
                id_vehiculo.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            id_vehiculo.Focus()
            id_vehiculo.Text = "0"
        End Try
    End Sub
    Private Sub Id_piloto_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Id_piloto.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(Id_piloto.Text)
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim QUERY = New SqlCeCommand("SELECT B.NOMBRE FROM TB_PILOTOS_TRANSPORTISTA A, TB_PILOTOS B WHERE B.ID_PILOTO = A.ID_PILOTO_ORIGINAL AND A.ID_TRANSPORTISTA = " & Convert.ToInt32(id_transportista.Text.Trim) & " AND A.ID_PILOTO = " & Convert.ToInt32(Id_piloto.Text.Trim) & " AND A.ESTADO = 'ACT';", CONN)
            Dim dr As SqlCeDataReader = Nothing
            Try
                If Id_piloto.Text.Length > 0 Then
                    CONN.Open()
                    dr = QUERY.ExecuteReader()
                    While dr.Read()
                        Piloto.Text = dr(0).ToString
                    End While
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por 13" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
            If valor < 0 Then
                MsgBox("ingrese numeros")
                Id_piloto.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            Id_piloto.Focus()
            Id_piloto.Text = "0"
        End Try
    End Sub

    Private Sub ALZ_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ALZ.LostFocus

        '' ''Dim valor As Integer = Nothing
        '' ''Try
        '' ''    valor = Convert.ToInt32(ALZ.Text)
        '' ''    If valor < 0 Then
        '' ''        MsgBox("ingrese numeros")
        '' ''        ALZ.Focus()
        '' ''    End If
        '' ''Catch ex As Exception
        '' ''    MsgBox("Ingrese numeros")
        '' ''    ALZ.Focus()
        '' ''    ALZ.Text = "0"
        '' ''End Try
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim drp As SqlCeDataReader = Nothing
        Dim nalz As Integer
        Dim mingo As Object = Convert.DBNull
        If ALZ.Text.Length > 0 Then
            Try
                Dim valor As Integer = Nothing
                valor = Convert.ToInt32(ALZ.Text)
                If valor < 0 Then
                    'MsgBox("ingrese numeros")
                    ALZ.Text = 0
                Else
                    nalz = Convert.ToInt32(ALZ.Text.Trim)
                    If tipot.Text <> "U" Then
                        Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA = 23 AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & nalz & ";", CONN)
                        Dim ALZADOR As Integer = 0
                        CONN.Open()
                        drp = QUERYp.ExecuteReader()
                        While drp.Read()
                            If (drp(0).Equals(mingo)) Then
                                ALZADOR = 0
                            Else
                                ALZADOR = Convert.ToInt32(drp(0).ToString.Trim)
                            End If
                        End While
                        If ALZADOR = 0 Then
                            MsgBox("Alzadora no valida")
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                ALZ.Focus()
                ALZ.Text = "0"
                MsgBox("Error ocasionado por 14" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
        End If
        CONN.Close()
    End Sub
    Private Sub TRA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TRA.LostFocus
        '' ''Dim valor As Integer = Nothing
        '' ''Try
        '' ''    valor = Convert.ToInt32(TRA.Text)
        '' ''    If valor < 0 Then
        '' ''        MsgBox("ingrese numeros")
        '' ''        TRA.Focus()
        '' ''    End If
        '' ''Catch ex As Exception
        '' ''    MsgBox("Ingrese numeros")
        '' ''    TRA.Focus()
        '' ''    TRA.Text = "0"
        '' ''End Try
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim drp As SqlCeDataReader = Nothing
        Dim ntrac As Integer
        Dim mingo As Object = Convert.DBNull
        If TRA.Text.Length > 0 Then
            Try
                Dim valor As Integer = Nothing
                valor = Convert.ToInt32(TRA.Text)
                If valor < 0 Then
                    'MsgBox("ingrese numeros")
                    TRA.Text = 0
                Else
                    ntrac = Convert.ToInt32(TRA.Text.Trim)
                    If tipot.Text <> "U" Then
                        Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA = 25 AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & ntrac & ";", CONN)
                        Dim TRACTOR As Integer = 0
                        CONN.Open()
                        drp = QUERYp.ExecuteReader()
                        While drp.Read()
                            If (drp(0).Equals(mingo)) Then
                                TRACTOR = 0
                            Else
                                TRACTOR = Convert.ToInt32(drp(0).ToString.Trim)
                            End If
                        End While
                        If TRACTOR = 0 Then
                            MsgBox("Tractor no valido")
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                TRA.Focus()
                TRA.Text = "0"
                MsgBox("Error ocasionado por 15" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
        End If
        CONN.Close()
    End Sub
    Private Sub ENV_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ENV.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(ENV.Text)
            If ((valor < 213) Or ((valor > 213) And (valor < 999)) Or ((valor > 10000) And (valor < 40000)) Or (valor > 90000)) Then
                MsgBox("Empleado no valido")
                corta.Focus()
            End If
            If valor < 0 Then
                MsgBox("ingrese numeros")
                cole.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            ENV.Focus()
            ENV.Text = "0"
        End Try
    End Sub
    Private Sub OPA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OPA.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(OPA.Text)
            If ((valor < 999) Or (valor > 90000)) Then 'Or ((valor > 10000) And (valor < 40000)) 
                'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                MsgBox("Empleado no valido")
                OPA.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            OPA.Focus()
            OPA.Text = "1000"
        End Try
    End Sub

    Private Sub OPT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OPT.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(OPT.Text)
            If ((valor < 999) Or (valor > 90000)) Then 'Or ((valor > 10000) And (valor < 40000))
                'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                MsgBox("Empleado no valido")
                OPT.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            OPT.Focus()
            OPT.Text = "1000"
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim QUERY = New SqlCeCommand("UPDATE TB_PARAMETROS SET ID_ALZADORA = " & Convert.ToInt32(ALZ.Text.Trim) & ", ID_OPERADOR_A =" & Convert.ToInt32(OPA.Text.Trim) & ", ID_TRACTOR = " & Convert.ToInt32(TRA.Text.Trim) & ", ID_OPERADOR_T = " & Convert.ToInt32(OPT.Text.Trim) & ", ID_ENVIERO = " & Convert.ToInt32(usuario.Text.Trim) & ";", CONN)
        'Dim dr As SqlCeDataReader = Nothing
        Dim REGISTROS As Integer
        Try
            CONN.Open()
            If CONN.State = Data.ConnectionState.Open Then
                REGISTROS = QUERY.ExecuteNonQuery
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por 16" & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub
    Private Sub Filas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Filas.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(Filas.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                Filas.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            Filas.Focus()
            Filas.Text = "0"
        End Try
    End Sub
    Private Sub posi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles posi.LostFocus
        Dim valor As Integer = Nothing
        Try
            If tipot.Text = "T" Then
                valor = Convert.ToInt32(posi.Text)
                If ((valor < 999) Or (valor > 90000)) Then
                    'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                    MsgBox("Empleado no valido")
                    posi.Focus()
                End If
            ElseIf tipot.Text = "M" Then
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                Dim drp As SqlCeDataReader = Nothing
                Dim ncosecha As Integer
                Dim mingo As Object = Convert.DBNull
                If posi.Text.Length > 0 Then
                    Try
                        Dim V_valor As Integer = Nothing
                        V_valor = Convert.ToInt32(posi.Text)
                        If V_valor < 0 Then
                            'MsgBox("ingrese numeros")
                            posi.Text = 0
                        Else
                            ncosecha = Convert.ToInt32(posi.Text.Trim)
                            If tipot.Text <> "U" Then
                                Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA = 46 AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & ncosecha & ";", CONN)
                                Dim cosecha As Integer = 0
                                CONN.Open()
                                drp = QUERYp.ExecuteReader()
                                While drp.Read()
                                    If (drp(0).Equals(mingo)) Then
                                        cosecha = 0
                                    Else
                                        cosecha = Convert.ToInt32(drp(0).ToString.Trim)
                                    End If
                                End While
                                If cosecha = 0 Then
                                    MsgBox("Cortadora no valida")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 17" & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                End If
                CONN.Close()
            Else
                valor = Convert.ToInt32(posi.Text)
                If valor < 0 Then
                    MsgBox("ingrese numeros")
                    posi.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            posi.Focus()
            posi.Text = "0"
        End Try
    End Sub
    Private Sub corta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles corta.LostFocus
        Dim valor As Integer = Nothing
        Try
            If corta.TextLength = 16 Then
                contraid.Text = Convert.ToInt32(corta.Text.Substring(6, 6)).ToString
                equivalencia.Text = corta.Text.Substring(12, 4).ToString
                corta.Text = Convert.ToInt32(corta.Text.Substring(0, 6)).ToString
            ElseIf corta.TextLength <= 6 Then
                corta.Text = Convert.ToInt32(corta.Text).ToString
            End If
            valor = Convert.ToInt32(corta.Text)
            If tipot.Text = "G" Or tipot.Text = "C" Then
            ElseIf tipot.Text = "M" Then
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                Dim drp As SqlCeDataReader = Nothing
                Dim ntrac As Integer
                Dim mingo As Object = Convert.DBNull
                If corta.Text.Length > 0 Then
                    Try
                        Dim V_valor As Integer = Nothing
                        V_valor = Convert.ToInt32(corta.Text)
                        If V_valor < 0 Then
                            'MsgBox("ingrese numeros")
                            corta.Text = 0
                        Else
                            ntrac = Convert.ToInt32(corta.Text.Trim)
                            If tipot.Text <> "U" Then
                                Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA IN(25,53) AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & ntrac & ";", CONN)
                                Dim tractor As Integer = 0
                                CONN.Open()
                                drp = QUERYp.ExecuteReader()
                                While drp.Read()
                                    If (drp(0).Equals(mingo)) Then
                                        tractor = 0
                                    Else
                                        tractor = Convert.ToInt32(drp(0).ToString.Trim)
                                    End If
                                End While
                                If tractor = 0 Then
                                    MsgBox("Tractor no valido")
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 18" & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                End If
                CONN.Close()
            Else
                If valor < 0 Then
                    'MsgBox("Ingrese numero")
                    corta.Focus()
                End If
            End If

        Catch ex As Exception
            'MsgBox("Ingrese numeros")
            corta.Focus()
            'corta.Text = "0"
        End Try
    End Sub
    Private Sub racimo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles racimo.LostFocus
        'Dim valor As Integer = Nothing
        'Try
        '    valor = Convert.ToInt32(racimo.Text)
        '    If valor < 0 Then
        '        MsgBox("ingrese numeros")
        '        racimo.Focus()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Ingrese numeros")
        '    racimo.Focus()
        '    racimo.Text = "0"
        'End Try
        If tipot.Text = "M" Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim drp As SqlCeDataReader = Nothing
            Dim ncarre As Integer
            Dim p_tipomaq As Integer
            Dim mingo As Object = Convert.DBNull
            If racimo.Text.Length > 0 Then
                Try
                    Dim valor As Integer = Nothing
                    valor = Convert.ToInt32(racimo.Text)
                    If valor <= 0 Then
                        MsgBox("ingrese numeros")
                        racimo.Text = 0
                    Else
                        ncarre = Convert.ToInt32(racimo.Text.Trim)
                        If tipot.Text <> "U" Then
                            If (tipot.Text = "M") Then
                                p_tipomaq = 53
                            Else
                                p_tipomaq = 27
                            End If
                            Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA = " & p_tipomaq & " AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & ncarre & ";", CONN)

                            Dim carreta As Integer = 0
                            CONN.Open()
                            drp = QUERYp.ExecuteReader()
                            While drp.Read()
                                If (drp(0).Equals(mingo)) Then
                                    carreta = 0
                                Else
                                    carreta = Convert.ToInt32(drp(0).ToString.Trim)
                                End If
                            End While
                            If carreta = 0 Then
                                MsgBox("Carreta no valida")
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por 19" & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
            End If
            CONN.Close()
        Else
            Dim valor As Integer = Nothing
            Try
                valor = Convert.ToInt32(racimo.Text)
                If valor <= 0 Then
                    MsgBox("ingrese numeros")
                    racimo.Focus()
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                racimo.Focus()
                racimo.Text = "0"
            End Try
        End If
    End Sub
    Private Sub op_alz_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles op_alz.LostFocus
        Dim valor As Integer = Nothing
        If (tipot.Text = "M") Then
            Try
                valor = Convert.ToInt32(op_alz.Text)
                If ((valor < 99) Or (valor > 90000)) Then 'Or ((valor > 10000) And (valor < 40000))
                    'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                    MsgBox("Empleado no valido")
                    op_alz.Focus()
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                op_alz.Focus()
                op_alz.Text = "1000"
            End Try
        Else
            '----------
            Try
                valor = Convert.ToInt32(op_alz.Text)
                If ((valor < 999) Or (valor > 90000)) Then 'Or ((valor > 10000) And (valor < 40000))
                    'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                    MsgBox("Empleado no valido")
                    op_alz.Focus()
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                op_alz.Focus()
                op_alz.Text = "1000"
            End Try
        End If
        '' ''Dim valor As Integer = Nothing
        '' ''Try
        '' ''    valor = Convert.ToInt32(op_alz.Text)
        '' ''    If valor < 0 Then
        '' ''        MsgBox("ingrese numeros")
        '' ''        op_alz.Focus()
        '' ''    End If
        '' ''Catch ex As Exception
        '' ''    MsgBox("Ingrese numeros")
        '' ''    op_alz.Focus()
        '' ''    op_alz.Text = "0"
        '' ''End Try
    End Sub

    Private Sub op_trac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles op_trac.LostFocus
        Dim valor As Integer = Nothing
        ''-------------------
        If (tipot.Text = "M") Then
            Try
                valor = Convert.ToInt32(op_trac.Text)
                If ((valor < 99) Or (valor > 90000)) Then 'Or ((valor > 10000) And (valor < 40000))
                    'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                    MsgBox("Empleado no valido")
                    op_trac.Focus()
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                op_trac.Focus()
                op_trac.Text = "1000"
            End Try
        Else
            Try
                valor = Convert.ToInt32(op_trac.Text)
                If ((valor < 999) Or (valor > 90000)) Then 'Or ((valor > 10000) And (valor < 40000))
                    'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                    MsgBox("Empleado no valido")
                    op_trac.Focus()
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                op_trac.Focus()
                op_trac.Text = "1000"
            End Try
        End If
        '' ''Dim valor As Integer = Nothing
        '' ''Try
        '' ''    valor = Convert.ToInt32(op_trac.Text)
        '' ''    If valor < 0 Then
        '' ''        MsgBox("ingrese numeros")
        '' ''        op_trac.Focus()
        '' ''    End If
        '' ''Catch ex As Exception
        '' ''    MsgBox("Ingrese numeros")
        '' ''    op_trac.Focus()
        '' ''    op_trac.Text = "0"
        '' ''End Try
    End Sub
    Private Sub fecha_corte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles fecha_corte.LostFocus
        Dim valor As DateTime = Nothing
        Try
            valor = Convert.ToDateTime(fecha_corte.Text)
            If valor > Now Then
                MsgBox("ingrese fecha")
                fecha_corte.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese fecha")
            fecha_corte.Focus()
        End Try
    End Sub
    Private Sub trato_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trato.CheckStateChanged
        If trato.CheckState = Windows.Forms.CheckState.Checked Then
            If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "L" Then
                Filas.Visible = True
                posi.Visible = True
                corta.Visible = True
                racimo.Visible = True
                op_alz.Visible = False
                op_trac.Visible = False
                Label7.Visible = False
                Label8.Visible = False
                equivalencia.Visible = True
                fecha_corte.Visible = True
                Button2.Visible = False
                Button3.Visible = False
                Agregar.Visible = True
                Borrar.Visible = True
                'editar.Visible = True
                lequivalencia.Visible = False
                Label6.Visible = False
                Label9.Visible = False
                cortadores.Visible = False
                'Button5.Visible = False
                Button6.Visible = False
                ncorta.Visible = False
                DateTimePicker1.Visible = True
                Label24.Visible = True
                id_contratista.Visible = True
            ElseIf tipot.Text = "T" Then
                posi.Visible = True
                equivalencia.Visible = True
                fecha_corte.Visible = True
                Button2.Visible = False
                Button3.Visible = False
                Agregar.Visible = True
                Borrar.Visible = True
                'editar.Visible = False
                lequivalencia.Visible = True
                Label6.Visible = False
                Label9.Visible = False
                cortadores.Visible = True
                'Button5.Visible = False
                Button6.Visible = False
                ncorta.Visible = True
                DateTimePicker1.Visible = True
                Label24.Visible = True
                id_contratista.Visible = True
            End If
        ElseIf trato.CheckState = Windows.Forms.CheckState.Unchecked Then
            If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "L" Then
                Filas.Visible = True
                posi.Visible = True
                corta.Visible = True
                racimo.Visible = True
                'op_alz.Visible = True
                'op_trac.Visible = True
                equivalencia.Visible = True
                fecha_corte.Visible = True
                Button2.Visible = True
                Button3.Visible = True
                Agregar.Visible = True
                Borrar.Visible = True
                'editar.Visible = True
                lequivalencia.Visible = True
                Label6.Visible = True
                Label9.Visible = True
                cortadores.Visible = True
                'Button5.Visible = True
                Button6.Visible = True
                ncorta.Visible = True
                DateTimePicker1.Visible = True
                Label24.Visible = False
                id_contratista.Visible = False
            ElseIf tipot.Text = "T" Then
                posi.Visible = True
                equivalencia.Visible = True
                fecha_corte.Visible = True
                Agregar.Visible = True
                Borrar.Visible = True
                'editar.Visible = False
                lequivalencia.Visible = True
                Label6.Visible = True
                Label9.Visible = True
                cortadores.Visible = True
                'Button5.Visible = True
                Button6.Visible = True
                ncorta.Visible = True
                DateTimePicker1.Visible = True
                Label24.Visible = True
                id_contratista.Visible = True
            End If
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim suma As Integer = 0
        If racimo.Text.Length < 1 Then
            racimo.Text = "1"
        Else
            suma = Convert.ToInt32(racimo.Text.Trim) + 1
            racimo.Text = Convert.ToString(suma)
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim resta As Integer = 0
        If racimo.Text.Length < 1 Then
            racimo.Text = "-1"
        Else
            resta = Convert.ToInt32(racimo.Text.Trim) - 1
            racimo.Text = Convert.ToString(resta)
        End If
    End Sub

    Public Sub Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregar.Click
        'f_valida_fecha_corte()
        ' f_valida_campo_contratista()
        '' If acumulador = 0 Then
        'numero_reporte()
        'End If
        Dim sum_racimo As Integer = 0
        Dim sum_racimo_total As Integer = 0
        Dim agrego As Integer = 0
        Dim salto As Integer = 0
        Dim contador As Integer = 0
        Dim countpos As Integer = 0
        Dim comparaa As String = ""
        Dim comparab As String = ""
        Dim posmas As Integer = 0
        Dim coincidencia As Integer = 0
        countpos = Convert.ToInt32(posi.Text) '?
        posmas = countpos
        If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
            If Filas.Text <> "" And posi.Text <> "" And corta.Text <> "" And racimo.Text <> "" And fecha_corte.Text <> "" And equivalencia.Text <> "" Then
                If detallet.TextLength > 0 Then
                    salto = Convert.ToInt32(detallet.TextLength / 35)
                    While contador < salto
                        comparab = detallet.Text.Substring(contador * 35, 6)
                        comparaa = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) '+ Lpad(corta.Text, "0", 6) '+ Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                        If comparaa = comparab Then
                            coincidencia = coincidencia + 1
                        End If
                        contador = contador + 1
                    End While
                    If coincidencia = 0 And Convert.ToInt32(cortadores.Text) < 40 Then
                        detallet.Text = detallet.Text + Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                    ElseIf coincidencia > 0 Then
                        MsgBox("los datos que quiere ingresar ya existen en este envio verifique")
                    Else
                        MsgBox("Ya ingreso el Maximo actual de cortadores (40)")
                        coincidencia = 1
                    End If
                Else
                    detallet.Text = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                End If
                If AscDes.Checked = True Then
                    posmas = posmas - 1
                ElseIf AscDes.Checked = False Then
                    posmas = posmas + 1
                Else
                    posmas = posmas - 1
                End If

                If coincidencia = 0 Then
                    'ñposmas = posmas + countpos
                    'Filas.Focus()
                    'Filas.Text = "0"
                    'Filas.ForeColor = Color.White
                    'posi.Text = ""
                    posi.Text = posmas
                    corta.Focus()
                    corta.Text = ""
                    racimo.Text = ""
                    'contraid.Text = ""
                    agrego = 1
                    'corta.ForeColor = Color.White
                    ' corta.Text = "1234"
                End If
                'fecha_corte.Text = ""
                'Equivalencia.Text = ""
            Else
                MsgBox("Los campos fila, posicion, cortador, uñadas, fecha de corte y equivalencia no deben quedar vacios ")
            End If
        ElseIf tipot.Text = "L" Then
            If Filas.Text <> "" And posi.Text <> "" And corta.Text <> "" And racimo.Text <> "" And fecha_corte.Text <> "" And equivalencia.Text <> "" Then
                If detallet.TextLength > 0 Then
                    salto = Convert.ToInt32(detallet.TextLength / 35)
                    While contador < salto
                        comparab = detallet.Text.Substring(contador * 35, 6)
                        comparaa = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) '+ Lpad(corta.Text, "0", 6) '+ Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                        If comparaa = comparab Then
                            coincidencia = coincidencia + 1
                        End If
                        contador = contador + 1
                    End While
                    If coincidencia = 0 And Convert.ToInt32(cortadores.Text) < 40 Then
                        detallet.Text = detallet.Text + Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                    ElseIf coincidencia > 0 Then
                        MsgBox("los datos que quiere ingresar ya existen en este envio verifique")
                    Else
                        MsgBox("Ya ingreso el Maximo actual de cortadores (40)")
                        coincidencia = 1
                    End If
                Else
                    detallet.Text = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                End If
                If AscDes.Checked = True Then
                    posmas = posmas - 1
                ElseIf AscDes.Checked = False Then
                    posmas = posmas + 1
                Else
                    posmas = posmas - 1
                End If
                'posmas = posmas + 1
                If coincidencia = 0 Then
                    posi.Text = posmas
                    corta.Focus()
                    corta.Text = ""
                    racimo.Text = ""
                    agrego = 1
                End If
            Else
                MsgBox("Los campos fila, posicion, cortador, uñadas, fecha de corte y equivalencia no deben quedar vacios ")
            End If
        ElseIf tipot.Text = "M" Then
            If posi.Text <> "" And corta.Text <> "" And racimo.Text <> "" And op_alz.Text <> "" And op_trac.Text <> "" Then
                If detallet.TextLength > 0 Then
                    detallet.Text = detallet.Text + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 3) + Lpad(racimo.Text, "0", 3) + Lpad(op_alz.Text, "0", 6) + Lpad(op_trac.Text, "0", 6)
                Else
                    detallet.Text = Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 3) + Lpad(racimo.Text, "0", 3) + Lpad(op_alz.Text, "0", 6) + Lpad(op_trac.Text, "0", 6)
                End If
                posi.Text = ""
                corta.Text = ""
                racimo.Text = ""
                op_alz.Text = ""
                op_trac.Text = ""
                agrego = 1
                posi.Focus()
            Else
                MsgBox("Los campos cortadora, tractor, carretas, operador c, operador t  no deben quedar vacios ")
            End If
        ElseIf tipot.Text = "T" Then
            If posi.Text <> "" And equivalencia.Text <> "" And fecha_corte.Text <> "" Then
                'ingresado
                If detallet.TextLength > 0 Then
                    salto = Convert.ToInt32(detallet.TextLength / 20)
                    While contador < salto
                        comparab = detallet.Text.Substring(contador * 20, 6)
                        comparaa = Lpad(posi.Text, "0", 6).ToUpper
                        If comparaa = comparab Then
                            coincidencia = coincidencia + 1
                        End If
                        contador = contador + 1
                    End While
                    If coincidencia = 0 Then
                        detallet.Text = detallet.Text + Lpad(posi.Text, "0", 6) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(fecha_corte.Text, "0", 8)
                    ElseIf coincidencia > 0 Then
                        MsgBox("los datos que quiere ingresar ya existen en este envio verifique")
                    End If
                Else
                    detallet.Text = Lpad(posi.Text, "0", 6) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(fecha_corte.Text, "0", 8)
                End If
                If coincidencia = 0 Then
                    posi.Text = ""
                    corta.Text = ""
                    racimo.Text = ""
                    agrego = 1
                End If
                'If detallet.TextLength > 0 Then
                '    detallet.Text = detallet.Text + Lpad(posi.Text, "0", 6) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(fecha_corte.Text, "0", 8)
                'Else
                '    detallet.Text = Lpad(posi.Text, "0", 6) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(fecha_corte.Text, "0", 8)
                'End If
                'posi.Text = ""
                'corta.Text = ""
                'racimo.Text = ""
                ''fecha_corte.Text = ""
                'agrego = 1
            Else
                MsgBox("Los campos cortador, equivalencia, fecha corte no deben quedar vacios ")
            End If
        ElseIf tipot.Text = "U" Then
            If corta.Text <> "" And racimo.Text <> "" Then
                If corta.Text.Length > 0 Then
                    If detallet.TextLength > 0 Then
                        detallet.Text = detallet.Text + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3)
                    Else
                        detallet.Text = Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3)
                    End If
                    corta.Text = ""
                    racimo.Text = ""
                    agrego = 1
                End If
            Else
                MsgBox("Los campos cortador, canastas no deben quedar vacios ")
            End If
        ElseIf tipot.Text = "V" Then
            If corta.Text <> "" And racimo.Text <> "" And posi.Text <> "" Then
                If corta.Text.Length > 0 Then
                    If detallet.TextLength > 0 Then
                        detallet.Text = detallet.Text + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(posi.Text, "0", 3)
                    Else
                        detallet.Text = Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(posi.Text, "0", 3)
                    End If
                    corta.Text = ""
                    racimo.Text = ""
                    posi.Text = ""
                    agrego = 1
                End If
            Else
                MsgBox("Los campos cortador, racimos y sacos no deben quedar vacios ")
            End If
        End If
        If agrego = 1 Then
            acumulador = acumulador + 1
        End If
        cortadores.Text = acumulador.ToString
        'SumaRacimo.Text = sum_racimo_total
    End Sub

    Private Sub Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Borrar.Click
        Dim RESPUESTA As MsgBoxResult = Nothing
        Dim largo As Integer = Nothing
        Dim menos As Integer = Nothing
        Dim registros As Integer = Nothing
        Dim texto As String = Nothing
        If tipot.Text = "M" Then
            menos = 21
        ElseIf tipot.Text = "T" Then
            menos = 20
        ElseIf tipot.Text = "G" Or tipot.Text = "C" Then
            menos = 35
        ElseIf tipot.Text = "U" Then
            menos = 9
        ElseIf tipot.Text = "V" Then
            menos = 12
        End If
        If Convert.ToInt32(ncorta.Text) > 0 Then
            RESPUESTA = MsgBox("Esta seguro que desea borrar?", MsgBoxStyle.YesNo, "Borrar")
            If RESPUESTA = MsgBoxResult.Yes Then
                largo = detallet.TextLength
                registros = largo / menos
                If largo > 0 Then
                    If Convert.ToInt32(ncorta.Text) = 1 Then
                        If largo > menos Then
                            texto = detallet.Text.Substring(menos, largo - menos)
                            detallet.Text = texto
                        Else
                            detallet.Text = ""
                            cortadores.Text = 0
                            ncorta.Text = 0
                        End If
                    ElseIf Convert.ToInt32(ncorta.Text) = registros Then
                        texto = detallet.Text.Substring(0, largo - menos)
                        detallet.Text = texto
                    Else
                        Dim hasta As Integer = Nothing
                        Dim desde As Integer = Nothing
                        hasta = (menos * (Convert.ToInt32(ncorta.Text) - 1))
                        desde = ((Convert.ToInt32(ncorta.Text) * menos))
                        texto = detallet.Text.Substring(0, hasta) + detallet.Text.Substring(desde, largo - desde)
                        detallet.Text = texto
                    End If
                    acumulador = acumulador - 1
                    Filas.Text = ""
                    posi.Text = ""
                    corta.Text = ""
                    racimo.Text = ""
                    op_alz.Text = ""
                    op_trac.Text = ""

                End If
                'detallet.Text = ""
                cortadores.Text = acumulador.ToString
            Else
                acumulador = acumulador
            End If
        Else
            MsgBox("No hay nada seleccionado para borrar")
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ' Dim largo As Integer = 0
        'Dim EDICION As String = ""
        navegar = 1
        If registro > 1 Then
            registro = registro - 1
            ncorta.Text = registro.ToString

            If tipot.Text = "G" Or tipot.Text = "C" Then
                largo = 35
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                Filas.Text = Replace(LTrim(Replace(EDICION.Substring(0, 3), "0", " ")), " ", "0")
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(3, 3), "0", " ")), " ", "0")
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(6, 6), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(12, 3), "0", " ")), " ", "0")
                fecha_corte.Text = EDICION.Substring(15, 8)
                equivalencia.Text = Replace(LTrim(Replace(EDICION.Substring(23, 6), "0", " ")), " ", "0")
                contraid.Text = Replace(LTrim(Replace(EDICION.Substring(29, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "L" Then
                largo = 35
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                Filas.Text = Replace(LTrim(Replace(EDICION.Substring(0, 3), "0", " ")), " ", "0")
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(3, 3), "0", " ")), " ", "0")
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(6, 6), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(12, 3), "0", " ")), " ", "0")
                fecha_corte.Text = EDICION.Substring(15, 8)
                equivalencia.Text = Replace(LTrim(Replace(EDICION.Substring(23, 6), "0", " ")), " ", "0")
                contraid.Text = Replace(LTrim(Replace(EDICION.Substring(29, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "M" Then
                largo = 21
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(0, 3), "0", " ")), " ", "0")
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(3, 3), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(6, 3), "0", " ")), " ", "0")
                op_alz.Text = Replace(LTrim(Replace(EDICION.Substring(9, 6), "0", " ")), " ", "0")
                op_trac.Text = Replace(LTrim(Replace(EDICION.Substring(15, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "T" Then
                largo = 20
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(0, 6), "0", " ")), " ", "0")
                fecha_corte.Text = EDICION.Substring(12, 8)
                equivalencia.Text = Replace(LTrim(Replace(EDICION.Substring(6, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "U" Then
                largo = 9
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(0, 6), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(6, 3), "0", " ")), " ", "0")
            End If
        End If
        If navegar = 1 Then
            Agregar.Visible = False
        Else
            Agregar.Visible = True
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Dim largo As Integer
        'Dim EDICION As String = ""
        navegar = 1
        If registro < acumulador Then
            registro = registro + 1
            ncorta.Text = registro.ToString
            If tipot.Text = "G" Or tipot.Text = "C" Then
                largo = 35
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                Filas.Text = Replace(LTrim(Replace(EDICION.Substring(0, 3), "0", " ")), " ", "0")
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(3, 3), "0", " ")), " ", "0")
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(6, 6), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(12, 3), "0", " ")), " ", "0")
                fecha_corte.Text = EDICION.Substring(15, 8)
                equivalencia.Text = Replace(LTrim(Replace(EDICION.Substring(23, 6), "0", " ")), " ", "0")
                contraid.Text = Replace(LTrim(Replace(EDICION.Substring(29, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "L" Then
                largo = 35
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                Filas.Text = Replace(LTrim(Replace(EDICION.Substring(0, 3), "0", " ")), " ", "0")
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(3, 3), "0", " ")), " ", "0")
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(6, 6), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(12, 3), "0", " ")), " ", "0")
                fecha_corte.Text = EDICION.Substring(15, 8)
                equivalencia.Text = Replace(LTrim(Replace(EDICION.Substring(23, 6), "0", " ")), " ", "0")
                contraid.Text = Replace(LTrim(Replace(EDICION.Substring(29, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "M" Then
                largo = 21
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(0, 3), "0", " ")), " ", "0")
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(3, 3), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(6, 3), "0", " ")), " ", "0")
                op_alz.Text = Replace(LTrim(Replace(EDICION.Substring(9, 6), "0", " ")), " ", "0")
                op_trac.Text = Replace(LTrim(Replace(EDICION.Substring(15, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "T" Then
                largo = 20
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                posi.Text = Replace(LTrim(Replace(EDICION.Substring(0, 6), "0", " ")), " ", "0")
                fecha_corte.Text = EDICION.Substring(12, 8)
                equivalencia.Text = Replace(LTrim(Replace(EDICION.Substring(6, 6), "0", " ")), " ", "0")
            ElseIf tipot.Text = "U" Then
                largo = 9
                EDICION = detallet.Text.Substring(((registro - 1) * largo), largo)
                corta.Text = Replace(LTrim(Replace(EDICION.Substring(0, 6), "0", " ")), " ", "0")
                racimo.Text = Replace(LTrim(Replace(EDICION.Substring(6, 3), "0", " ")), " ", "0")
            End If
        Else
            navegar = 0
            Filas.Text = ""
            posi.Text = ""
            corta.Text = ""
            racimo.Text = ""
            op_alz.Text = ""
            op_trac.Text = ""
        End If
        If navegar = 1 Then
            Agregar.Visible = False
        Else
            Agregar.Visible = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            flete = "P"
        Else
            flete = ""
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            flete = "F"
        Else
            flete = ""
        End If
    End Sub
    Private Sub cuenta_unadas()
        corte = (detallet.Text.Length / 35)
        salto = 1
        LecturaF.Text = 0
        'MsgBox(corte)
        total_deta_u = 0
        While salto <= corte
            linea = ""
            coordenada = coordenada + 30
            linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
            total_deta_u = total_deta_u + Convert.ToInt32(linea.Substring(12, 3))
            salto = salto + 1
            LecturaF.Text = LecturaF.Text + 1
            lv_unidad = total_deta_u
        End While
    End Sub
    Private Sub cuenta_carretas()
        If (tipot.Text = "L") Then
            corte = (detallet.Text.Length / 35)
            salto = 1
            LecturaF.Text = 0
            total_deta_c = 0
            subtotal_deta_c = 0
            While salto <= corte
                linea = ""
                coordenada = coordenada + 30
                linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                subtotal_deta_c = Convert.ToInt32(linea.Substring(12, 3))
                If subtotal_deta_c.ToString.Length > 0 Then
                    conteo = 1
                    total_deta_c = total_deta_c + conteo
                    lv_unidad = total_deta_c
                End If
                'total_deta_c = total_deta_c + Convert.ToInt32(linea.Substring(6, 3))
                salto = salto + 1
                LecturaF.Text = LecturaF.Text + 1
            End While
        Else
            corte = (detallet.Text.Length / 21)
            salto = 1
            LecturaF.Text = 0
            total_deta_c = 0
            subtotal_deta_c = 0
            While salto <= corte
                linea = ""
                coordenada = coordenada + 30
                linea = detallet.Text.Substring(LecturaF.Text * 21, 21)
                subtotal_deta_c = Convert.ToInt32(linea.Substring(6, 3))
                If subtotal_deta_c.ToString.Length > 0 Then
                    conteo = 1
                    total_deta_c = total_deta_c + conteo
                    lv_unidad = total_deta_c
                End If
                'total_deta_c = total_deta_c + Convert.ToInt32(linea.Substring(6, 3))
                salto = salto + 1
                LecturaF.Text = LecturaF.Text + 1
            End While
        End If
    End Sub

    Private Sub Generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generar.Click
        If IMPRESIONES2 = 0 Then
            numero_reporte()
            f_grabar_envio()
            ''End If
            '' If IMPRESIONES < 1 Then
            ''f_grabar_envio()
            ''coleccion.TabIndex(5).enabled = False
            ''coleccion.TabPages(5).Parent = Nothing
            ''coleccion.TabPages(7).Parent = Nothing
            f_bloquea_campos()
            'ElseIf (IMPRESIONES2 >= 3) Then
            '   If (tipot.Text = "M") Then
            'Generar.Enabled = False
            'End If
        ElseIf (IMPRESIONES2 = 2) Then
            If (tipo_finca.Text.Trim = "3" Or tipo_finca.Text.Trim = "4" Or tipo_finca.Text.Trim = "5") Then
                f_imprimir_envio()
            Else
                Generar.Enabled = False
            End If
        ElseIf (IMPRESIONES2 = 3) Then
            Generar.Enabled = False        
        Else
            f_imprimir_envio()
        End If
        'f_imprimir_envio()
    End Sub
    Private Sub f_imprimir_envio()
        'If IMPRESIONES = 0 Then
        '    numero_reporte()
        'Else
        '    NUMERO_REP = NUMERO_REP
        'End If

        numerou1new = unidad.Text
        If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
            cuenta_unadas()
        ElseIf ((tipot.Text = "M") Or (tipot.Text = "L")) Then
            cuenta_carretas()
        End If
        If bandera = 0 Then
            If acumulador <= 0 And trato.CheckState = Windows.Forms.CheckState.Checked Then
                MsgBox("Debe Llenar los datos una vez")
            Else
                Dim RESPUESTA As MsgBoxResult = Nothing
                Dim contador_generar As Integer = 0
                Dim espera As Long = 0
                TOTAL_SACOS = 0
                fecha_env = Now.ToString("yyyyMMdd HH:mm")
                Generado.Text = ""
                detallegc = ""
                'MsgBox(fecha_env)

                'While txtLatitud.Text.Length = 0 And txtLongitud.Text.Length = 0
                '    espera = espera + 1
                '    If espera > 2000000000 Then
                '        espera = 0
                '    End If
                'End While
                'If txtLon1.Text.Length > 1 And txtLat1.Text.Length > 1 And txtLon2.Text.Length > 1 And txtLat2.Text.Length > 1 And txtLon3.Text.Length > 1 And txtLat3.Text.Length > 1 And TxtLon4.Text.Length > 1 And TxtLat4.Text.Length > 1 Then
                '    If Not position Is Nothing Then
                '        txtResult.Text = position.EnCerca(txtLon1.Text, txtLat1.Text, txtLon2.Text, txtLat2.Text, txtLon3.Text, txtLat3.Text, TxtLon4.Text, TxtLat4.Text).ToString
                '    End If
                'End If
                Try
                    If Not position Is Nothing Then
                        txtResult.Text = position.EnCerca(txtLon1.Text, txtLat1.Text, txtLon2.Text, txtLat2.Text, txtLon3.Text, txtLat3.Text, TxtLon4.Text, TxtLat4.Text).ToString
                    End If
                Catch EX As Exception
                    MsgBox("Error producido por gps " & EX.Message & vbCrLf, Nothing, "Error")
                End Try
                'cambio esto va en la funcion de grabar  10-02-2014
                'If tipot.Text <> "U" And tipot.Text <> "V" Then
                '    zona.Text = Lizona.Items.Item(Lizona.SelectedIndex)
                '    If lilo1.SelectedIndex < 0 Then
                '        lote1 = ""
                '    Else
                '        lote1 = lilo1.Items.Item(lilo1.SelectedIndex).ToString()
                '    End If
                '    If lilo2.SelectedIndex < 0 Then
                '        lote2 = ""
                '    Else
                '        lote2 = lilo2.Items.Item(lilo2.SelectedIndex).ToString()
                '    End If
                '    If lilo3.SelectedIndex < 0 Then
                '        lote3 = ""
                '    Else
                '        lote3 = lilo3.Items.Item(lilo3.SelectedIndex).ToString()
                '    End If
                '    If lilo4.SelectedIndex < 0 Then
                '        lote4 = ""
                '    Else
                '        lote4 = lilo4.Items.Item(lilo4.SelectedIndex).ToString()
                '    End If
                '    If lilo5.SelectedIndex < 0 Then
                '        lote5 = ""
                '    Else
                '        lote5 = lilo5.Items.Item(lilo5.SelectedIndex).ToString()
                '    End If
                '    If lilo6.SelectedIndex < 0 Then
                '        lote6 = ""
                '    Else
                '        lote6 = lilo6.Items.Item(lilo6.SelectedIndex).ToString()
                '    End If
                '    If lipa1.SelectedIndex < 0 Then
                '        pante1 = ""
                '    Else
                '        pante1 = lipa1.Items.Item(lipa1.SelectedIndex).ToString()
                '    End If
                '    If lipa2.SelectedIndex < 0 Then
                '        pante2 = ""
                '    Else
                '        pante2 = lipa2.Items.Item(lipa2.SelectedIndex).ToString()
                '    End If
                '    If lipa3.SelectedIndex < 0 Then
                '        pante3 = ""
                '    Else
                '        pante3 = lipa3.Items.Item(lipa3.SelectedIndex).ToString()
                '    End If
                '    If lipa4.SelectedIndex < 0 Then
                '        pante4 = ""
                '    Else
                '        pante4 = lipa4.Items.Item(lipa4.SelectedIndex).ToString()
                '    End If
                '    If lipa5.SelectedIndex < 0 Then
                '        pante5 = ""
                '    Else
                '        pante5 = lipa5.Items.Item(lipa5.SelectedIndex).ToString()
                '    End If
                '    If lipa6.SelectedIndex < 0 Then
                '        pante6 = ""
                '    Else
                '        pante6 = lipa6.Items.Item(lipa6.SelectedIndex).ToString()
                '    End If
                'End If
                'fin del cambio erick 10-02-2014
                If presenta.Checked Then
                    presentacion = "Q"
                Else
                    presentacion = "C"
                End If
                '----------------------------verifica la ruta
                'If (tipot.Text = "T") Then
                '    If (ruta.Text.Length > 0) Then
                '        If (id_ruta.Text <> ruta.Text) Then

                '        End If
                '    End If
                'End If
                '----------------------------

                If ((tipot.Text = "C") Or (tipot.Text = "G")) Then 'ticket = boleta de transporte'
                    If detallet.TextLength > 0 Then
                        salto = Convert.ToInt32(detallet.TextLength / 35)
                        While contador_generar < salto
                            Dim linea As String = ""
                            linea = detallet.Text.Substring(contador_generar * 35, 35) 'comparab = detalle.Text.Substring(CONTADOR * 35, 35)
                            detallegc = detallegc + Lpad(linea.Substring(0, 3), "0", 3) + Lpad(linea.Substring(3, 3), "0", 3) + Lpad(linea.Substring(6, 6), "0", 6) + Lpad(linea.Substring(12, 3), "0", 3) + Lpad(linea.Substring(15, 8), "0", 8) + Lpad(linea.Substring(23, 6), "0", 6).ToUpper + Lpad(linea.Substring(29, 6), "0", 6).ToUpper
                            contador_generar = contador_generar + 1
                        End While
                    End If

                    If trato.Checked = True Then
                        If (tipot.Text = "L") Then
                            Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(numerou1new, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallegc
                        Else
                            Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(lv_unidad, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallegc
                        End If
                    Else
                        If (tipot.Text = "L") Then
                            Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(numerou1new, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallegc
                        Else
                            Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(lv_unidad, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallegc
                        End If
                        'Dim otro As Integer = Generado.TextLength
                        'otro = otro
                    End If

                ElseIf (tipot.Text = "L") Then
                        If detallet.TextLength > 0 Then
                            salto = Convert.ToInt32(detallet.TextLength / 35)
                            While contador_generar < salto
                                Dim linea As String = ""
                                linea = detallet.Text.Substring(contador_generar * 35, 35) 'comparab = detalle.Text.Substring(CONTADOR * 35, 35)
                                detallegc = detallegc + Lpad(linea.Substring(0, 3), "0", 3) + Lpad(linea.Substring(3, 3), "0", 3) + Lpad(linea.Substring(6, 6), "0", 6) + Lpad(linea.Substring(12, 3), "0", 3) + Lpad(linea.Substring(15, 8), "0", 8) + Lpad(linea.Substring(23, 6), "0", 6).ToUpper + Lpad(linea.Substring(29, 6), "0", 6).ToUpper
                                contador_generar = contador_generar + 1
                            End While
                        End If
                        If flete = "P" Then
                            texto = "PROPIO"
                        Else
                            texto = "FLETERO"
                    End If
                    If (tipot.Text = "L") Then
                        unidad.Text = unidad.Text
                        numerou1new = unidad.Text
                    Else
                        unidad.Text = cortadores.Text
                    End If
                    ALZ.Text = "000000"
                    TRA.Text = "000000"
                    OPA.Text = "000000"
                    OPT.Text = "000000"

                    ' fe_quema_old = fe_quema.Text.Substring(0, 8)
                    fe_quema_old = fe_quema.Text
                    Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(id_contratista.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(pante1, "0", 3) + Lpad(lote1, "0", 3) + Lpad(numerou1new, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
                    ElseIf (tipot.Text = "M") Then
                    Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(lv_unidad, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(cole.Text, "0", 3) + Lpad(presentacion, "0", 2) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallet.Text
                    ElseIf (tipot.Text = "T") Then
                        If trato.Checked = True Then
                        Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(id_contratista.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(id_ruta.Text, "0", 3) + Lpad(zona.Text, "0", 2) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallet.Text
                        Else
                        Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(id_contratista.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(id_ruta.Text, "0", 3) + Lpad(zona.Text, "0", 2) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + Lpad(SerieCroquis.Text, "0", 5) + detallet.Text
                        End If
                    ElseIf (tipot.Text = "U") Then
                        Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + detallet.Text
                    ElseIf (tipot.Text = "V") Then
                        Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + detallet.Text
                    End If
                    If BTPRINT.IsOpen Then
                        BTPRINT.Close()
                    End If

                    Try
                        BTPRINT.Open()
                        BTPRINT.WriteTimeout = 90000
                        'BTPRINT.WriteTimeout = System.IO.Ports.SerialPort.InfiniteTimeout 'serial.InfiniteTimeout


                        coordenada = 10
                        nombre_empresa = ""
                        NOMBRE_BOLETA = ""
                        unidades.Text = ""
                        ENC = ""
                        If Empresa.Text = "1" Then
                        nombre_empresa = "Ingenio El Pilar, S.A."
                        ElseIf Empresa.Text = "6326" Then
                            nombre_empresa = "TIKINDUSTRIAS, S. A."
                        Else
                            If Empresa.Text = "6327" Then
                                nombre_empresa = "PALMA SUR, S. A."
                            End If
                        End If
                        If tipot.Text = "L" And cole_mal.Text.Length >= "1" Then
                            NOMBRE_BOLETA = "NOTA DE ENVIO DE CAÑA MALETEADA (COLERA)"
                            unidades.Text = "MALETAS"
                        ElseIf tipot.Text = "M" And cole_meca.Text.Length >= "1" Then
                            NOMBRE_BOLETA = "NOTA DE ENVIO DE CAÑA MECANIZADA(COLERA)"
                            unidades.Text = "CARRETAS"
                        Else
                            If tipot.Text = "C" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL (COLERA)"
                                unidades.Text = "UNADAS"
                            ElseIf tipot.Text = "G" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL"
                                unidades.Text = "UNADAS"
                            ElseIf tipot.Text = "M" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA COSECHA MECANIZADA"
                                unidades.Text = "CARRETAS"
                            ElseIf tipot.Text = "L" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA MALETEADA"
                                unidades.Text = "MALETAS"
                            ElseIf tipot.Text = "T" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA TRAMEADO"
                                unidades.Text = "MALETAS"
                            ElseIf tipot.Text = "U" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A FABRICA"
                                unidades.Text = "CANASTAS"
                            ElseIf tipot.Text = "V" Then
                                NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A VENTA"
                                unidades.Text = "RACIMOS"
                            End If
                        End If
                        ENC = Chr(27) & "EZ" & "{PRINT:" & "@" & coordenada & ",200:MF107,VMULT2|" & nombre_empresa & "|"
                        coordenada = coordenada + 70
                        ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & NOMBRE_BOLETA & "|"
                        If Empresa.Text = "6327" Then
                            coordenada = coordenada + 70
                            ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & serie_preparada & "|"
                        ElseIf Empresa.Text = "6326" Then
                            coordenada = coordenada + 70
                            ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & serie_preparada & "|"
                        Else
                            coordenada = coordenada + 70
                        ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                     SERIE: " & serie_preparada & "|"
                        End If
                    'coordenada = coordenada + 70
                        ENC &= "@" & coordenada & ", 50:MF107, VMULT2|ENVIO NO.:   " & Lpad(NUMERO_REP, "0", 6) & "|"
                        ENC &= "}" & "{AHEAD:12}" & "{LP}"
                        BTPRINT.Write(ENC)
                        coordenada = 10
                        IMP = Chr(27) & "EZ" & "{PRINT:" & "@" & coordenada & ",50:MF204,VMULT1 |FECHA:       " & Now.ToString("dd/MM/yyyy HH:mm") & "|"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204,VMULT1 |FINCA:       " & Lpad(Id_finca.Text, "0", 3) & "  " & Nombre_finca.Text & "|"
                        coordenada = coordenada + 30
                        If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CROQUIS:                 " + SerieCroquis.Text + "    " & Lpad(Croquis.Text, "0", 8) & "|" '"  " & nombre_trans & 
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ORDEN CORTE:             " & Lpad(ocorte.Text, "0", 8) & "|" '"  " & nombre_trans & 
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(trans.Text, "0", 4) & "|" '"  " & nombre_trans & 
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(pilo.Text, "0", 3) & "|" '"  " & nombre_pilo &
                            coordenada = coordenada + 30
                        If (tipot.Text = "T" Or tipot.Text = "L") Then
                            If (p_placa.Length > 0) Then
                                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "      Placas:  " + p_placa + "|"
                            Else
                                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "      Placas:  " + txtPLaca.Text + "|"
                            End If
                        Else
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "|"
                        End If
                        coordenada = coordenada + 30
                        If ((tipot.Text = "T") Or (tipot.Text = "L")) Then
                            If (Manual.CheckState = Windows.Forms.CheckState.Checked) Then
                                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |Placa Manual |"
                            Else
                                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |STICKER |"
                            End If
                        End If
                    Else
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(trans.Text, "0", 4) & "  " & nombre_trans & "|"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(pilo.Text, "0", 3) & "  " & nombre_pilo & "|" '
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "  " & placa_vehi & "|" '
                    End If
                    If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204,VMULT1 |FRENTE:                  " & Lpad(Id_Frente.Text, "0", 3) & "|"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |BOLETA DE TRANSPORTE:    " & Lpad(Nboleta.Text, "0", 6) & "|"
                    Else
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204,VMULT1 |SECTOR:                  " & Lpad(Id_Frente.Text, "0", 3) & "|"
                    End If
                    If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |RUTA:                    " & Lpad(id_ruta.Text, "0", 3) & "|"
                    End If
                    If (tipot.Text <> "T") Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PLATAFORMA:              " & Lpad(plata.Text, "0", 4) & "|"
                    End If
                    If ((tipot.Text = "C") Or (tipot.Text = "G") Or (tipot.Text = "M") Or (tipot.Text = "L")) Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |COLERA:                  " & Lpad(cole.Text, "0", 4) & "|"
                    End If
                    If ((tipot.Text <> "M") And (tipot.Text <> "T") And (tipot.Text <> "L")) Then
                        If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(contraid.Text, "0", 4) & "|" ' "  " & nombre_contra &
                        Else
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(contraid.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                        End If
                    End If
                    If (tipot.Text = "T") Then
                        If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "|" ' "  " & nombre_contra &
                        Else
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                        End If
                    End If
                    If (tipot.Text = "L") Then
                        If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "|" ' "  " & nombre_contra &
                        Else
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                        End If
                    End If
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |HORA DE DESPACHO:        " & TimeOfDay.ToString("HH:mm") & "|"
                    'If (tipo <> "U") Then
                    coordenada = coordenada + 30
                    If (tipot.Text <> "U") And (tipot.Text <> "T") And (tipot.Text <> "V") Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TURNO:                   " & grupo.Text & "|"
                    ElseIf tipot.Text = "T" Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CUADRILLA:               " & grupo.Text & "|"
                    Else
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |GRUPO:                   " & grupo.Text & "|"
                    End If
                    If tipot.Text = "V" Or tipot.Text = "U" Then
                        Dim DATO As DateTime = Now
                        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                        Dim QUERY = New SqlCeCommand()
                        Dim dr As SqlCeDataReader = Nothing

                        QUERY = New SqlCeCommand("SELECT FECHA_SIEMBRA FROM TB_LOTES WHERE ID_FINCA =  " & Id_finca.Text & " AND ID_PANTE = " & Id_Frente.Text & " AND ID_LOTE = " & lipa1.Items.Item(lipa1.SelectedIndex) & " ;", CONN)
                        Try
                            If CONN.State = Data.ConnectionState.Open Then
                                CONN.Close()
                            Else
                                CONN.Open()
                            End If
                            dr = QUERY.ExecuteReader()
                            While dr.Read()
                                DATO = Convert.ToDateTime(dr(0).ToString)
                            End While
                        Catch ex As Exception
                            MsgBox("Error ocasionado por 21 " & ex.Message & vbCrLf & _
                                        "Favor de reportarlo.")
                        End Try
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PERIODO SIEMBRA:        " & DATO.ToString("yyyy") & "|"
                    End If
                    If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ALZADOR:                 " & Lpad(ALZ.Text, "0", 3) & "     OPERADOR ALZADOR " & Lpad(OPA.Text, "0", 6) & "|"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRACTOR:                 " & Lpad(TRA.Text, "0", 3) & "     OPERADOR TRACTOR " & Lpad(OPT.Text, "0", 6) & "|"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FECHA TURNO:                 " & Lpad(fecturno.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecturno.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecturno.Text.Substring(4, 4), "0", 4) & "|"
                    End If
                    coordenada = coordenada + 30
                    total_unidades = 0
                    If unidad.Text = "" Then
                        total_unidades = total_unidades + 0
                    Else
                        total_unidades = total_unidades + Convert.ToInt32(unidad.Text)
                    End If
                    If unidad2.Text = "" Then
                        total_unidades = total_unidades + 0
                    Else
                        total_unidades = total_unidades + Convert.ToInt32(unidad2.Text)
                    End If
                    If unidad3.Text = "" Then
                        total_unidades = total_unidades + 0
                    Else
                        total_unidades = total_unidades + Convert.ToInt32(unidad3.Text)
                    End If
                    If unidad4.Text = "" Then
                        total_unidades = total_unidades + 0
                    Else
                        total_unidades = total_unidades + Convert.ToInt32(unidad4.Text)
                    End If
                    If unidad5.Text = "" Then
                        total_unidades = total_unidades + 0
                    Else
                        total_unidades = total_unidades + Convert.ToInt32(unidad5.Text)
                    End If
                    If unidad6.Text = "" Then
                        total_unidades = total_unidades + 0
                    Else
                        total_unidades = total_unidades + Convert.ToInt32(unidad6.Text)
                    End If
                    'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & UNIDADES & ":        " & total_unidades & "|"

                    If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PRESENTACION:                 " & Lpad(presentacion, "0", 1) & "|"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |      LOTE          FECHA QUEMA      HORA QUEMA      " & unidades.Text & "|"
                    Else
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |BLOQUE    VARIEDAD  FECHA CORTE      HORA CORTE      " & unidades.Text & "|"
                    End If
                    'inicia cambio esto va en la funcion de grabar
                    'fechaq1 = Lpad(fe_quema.Text, "0", 8)
                    'fechaq2 = Lpad(quema2.Text, "0", 8)
                    'fechaq3 = Lpad(quema3.Text, "0", 8)
                    'fechaq4 = Lpad(quema4.Text, "0", 8)
                    'fechaq5 = Lpad(quema5.Text, "0", 8)
                    'fechaq6 = Lpad(quema6.Text, "0", 8)
                    'horaq1 = Lpad(Ho_quema.Text, "0", 4)
                    'horaq2 = Lpad(hora2.Text, "0", 4)
                    'horaq3 = Lpad(hora3.Text, "0", 4)
                    'horaq4 = Lpad(hora4.Text, "0", 4)
                    'horaq5 = Lpad(hora5.Text, "0", 4)
                    'horaq6 = Lpad(hora6.Text, "0", 4)
                    ''erick cambio 10-02-2014
                    If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                        SumaRacimo.Text = total_deta_u
                        SumaCarreta.Text = total_deta_c
                        coordenada = coordenada + 30

                        If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(SumaRacimo.Text, "0", 3) & "|"
                        ElseIf (tipot.Text = "M") Then
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(SumaCarreta.Text, "0", 3) & "|"
                        ElseIf (tipot.Text = "L") Then
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(numerou1new, "0", 3) & "|"
                        Else
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                        End If

                        If lote2.Length > 0 Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante2, "0", 3) & "       " & Lpad(lote2, "0", 3) & "       " & fechaq2.Substring(0, 2) & "/" & fechaq2.Substring(2, 2) & "/" & fechaq2.Substring(4, 4) & "        " & horaq2.Substring(0, 2) & ":" & horaq2.Substring(2, 2) & "         " & Lpad(unidad2.Text, "0", 3) & "|"
                        End If
                        If lote3.Length > 0 Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante3, "0", 3) & "       " & Lpad(lote3, "0", 3) & "       " & fechaq3.Substring(0, 2) & "/" & fechaq3.Substring(2, 2) & "/" & fechaq3.Substring(4, 4) & "        " & horaq3.Substring(0, 2) & ":" & horaq3.Substring(2, 2) & "         " & Lpad(unidad3.Text, "0", 3) & "|"
                        End If
                        If lote4.Length > 0 Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante4, "0", 3) & "       " & Lpad(lote4, "0", 3) & "       " & fechaq4.Substring(0, 2) & "/" & fechaq4.Substring(2, 2) & "/" & fechaq4.Substring(4, 4) & "        " & horaq4.Substring(0, 2) & ":" & horaq4.Substring(2, 2) & "         " & Lpad(unidad4.Text, "0", 3) & "|"
                        End If
                        If lote5.Length > 0 Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante5, "0", 3) & "       " & Lpad(lote5, "0", 3) & "       " & fechaq5.Substring(0, 2) & "/" & fechaq5.Substring(2, 2) & "/" & fechaq5.Substring(4, 4) & "        " & horaq5.Substring(0, 2) & ":" & horaq5.Substring(2, 2) & "         " & Lpad(unidad5.Text, "0", 3) & "|"
                        End If
                        If lote6.Length > 0 Then
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante6, "0", 3) & "       " & Lpad(lote6, "0", 3) & "       " & fechaq6.Substring(0, 2) & "/" & fechaq6.Substring(2, 2) & "/" & fechaq6.Substring(4, 4) & "        " & horaq6.Substring(0, 2) & ":" & horaq6.Substring(2, 2) & "         " & Lpad(unidad6.Text, "0", 3) & "|"
                        End If
                    Else
                        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                        Dim QUERY = New SqlCeCommand()
                        Dim dr As SqlCeDataReader = Nothing

                        QUERY = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote1 & " ;", CONN)
                        Try
                            If CONN.State = Data.ConnectionState.Open Then
                                CONN.Close()
                            Else
                                CONN.Open()
                            End If
                            dr = QUERY.ExecuteReader()
                            While dr.Read()
                                VARIEDAD_DESC = dr(0).ToString
                            End While
                        Catch ex As Exception
                            MsgBox("Error ocasionado por 22 " & ex.Message & vbCrLf & _
                                        "Favor de reportarlo.")
                        End Try
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                        If lote2.Length > 0 Then
                            QUERY = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN)
                            Try
                                If CONN.State = Data.ConnectionState.Open Then
                                    CONN.Close()
                                Else
                                    CONN.Open()
                                End If
                                dr = QUERY.ExecuteReader()
                                While dr.Read()
                                    VARIEDAD_DESC = dr(0).ToString
                                End While
                            Catch ex As Exception
                                MsgBox("Error ocasionado por 23 " & ex.Message & vbCrLf & _
                                            "Favor de reportarlo.")
                            End Try
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante2, "0", 3) & "       " & Lpad(lote2, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq2.Substring(0, 2) & "/" & fechaq2.Substring(2, 2) & "/" & fechaq2.Substring(4, 4) & "        " & horaq2.Substring(0, 2) & ":" & horaq2.Substring(2, 2) & "         " & Lpad(unidad2.Text, "0", 3) & "|"

                        End If
                        If lote3.Length > 0 Then
                            QUERY = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN)
                            Try
                                If CONN.State = Data.ConnectionState.Open Then
                                    CONN.Close()
                                Else
                                    CONN.Open()
                                End If
                                dr = QUERY.ExecuteReader()
                                While dr.Read()
                                    VARIEDAD_DESC = dr(0).ToString
                                End While
                            Catch ex As Exception
                                MsgBox("Error ocasionado por 24 " & ex.Message & vbCrLf & _
                                            "Favor de reportarlo.")
                            End Try
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante3, "0", 3) & "       " & Lpad(lote3, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq3.Substring(0, 2) & "/" & fechaq3.Substring(2, 2) & "/" & fechaq3.Substring(4, 4) & "        " & horaq3.Substring(0, 2) & ":" & horaq3.Substring(2, 2) & "         " & Lpad(unidad3.Text, "0", 3) & "|"
                        End If
                        If lote4.Length > 0 Then
                            QUERY = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN)
                            Try
                                If CONN.State = Data.ConnectionState.Open Then
                                    CONN.Close()
                                Else
                                    CONN.Open()
                                End If
                                dr = QUERY.ExecuteReader()
                                While dr.Read()
                                    VARIEDAD_DESC = dr(0).ToString
                                End While
                            Catch ex As Exception
                                MsgBox("Error ocasionado por 25 " & ex.Message & vbCrLf & _
                                            "Favor de reportarlo.")
                            End Try
                            coordenada = coordenada + 30
                            IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante4, "0", 3) & "       " & Lpad(lote4, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq4.Substring(0, 2) & "/" & fechaq4.Substring(2, 2) & "/" & fechaq4.Substring(4, 4) & "        " & horaq4.Substring(0, 2) & ":" & horaq4.Substring(2, 2) & "         " & Lpad(unidad4.Text, "0", 3) & "|"
                        End If
                    End If
                    coordenada = coordenada + 30
                    If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR            UNADAS      FECHA CORTE      EQUIVALENCIA|"
                        'MsgBox(detalle.Text.Length / 12)
                        corte = (detallet.Text.Length / 35)
                        salto = 1
                        LecturaF.Text = 0
                        'MsgBox(corte)
                        total_detalle = 0
                        While salto <= corte
                            linea = ""
                            coordenada = coordenada + 30
                            linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                            'MsgBox("linea: " & linea)
                            'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "    " & linea.Substring(3, 3) & "        " & linea.Substring(6, 6) & "  " & linea.Substring(29, 6) & "         " & linea.Substring(12, 3) & "      " & linea.Substring(15, 2) & "/" & linea.Substring(17, 2) & "/" & linea.Substring(19, 4) & "       " & linea.Substring(23, 6) & "|"
                            total_detalle = total_detalle + Convert.ToInt32(linea.Substring(12, 3))
                            If ((salto = 25) Or (salto = 50)) Then
                                IMP &= "}" & "{AHEAD:0}" & "{LP}"
                                BTPRINT.Write(IMP)
                                IMP = Chr(27) & "EZ" & "{PRINT: "
                                coordenada = 0
                            End If
                            salto = salto + 1
                            LecturaF.Text = LecturaF.Text + 1
                        End While
                        ''temporal erick''
                        'If trato.Checked = True Then
                        '    coordenada = coordenada + 30
                        '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                                  " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "             |"
                        'End If
                        ''
                    ElseIf (tipot.Text = "L") Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR            QUINTALES      FECHA CORTE      EQUIVALENCIA|"
                        'MsgBox(detalle.Text.Length / 12)
                        corte = (detallet.Text.Length / 35)
                        salto = 1
                        LecturaF.Text = 0
                        'MsgBox(corte)
                        total_detalle = 0
                        While salto <= corte
                            linea = ""
                            coordenada = coordenada + 30
                            linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                            'MsgBox("linea: " & linea)
                            'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "    " & linea.Substring(3, 3) & "        " & linea.Substring(6, 6) & "  " & linea.Substring(29, 6) & "         " & linea.Substring(12, 3) & "      " & linea.Substring(15, 2) & "/" & linea.Substring(17, 2) & "/" & linea.Substring(19, 4) & "       " & linea.Substring(23, 6) & "|"
                            total_detalle = total_detalle + Convert.ToInt32(linea.Substring(12, 3))
                            If ((salto = 25) Or (salto = 50)) Then
                                IMP &= "}" & "{AHEAD:0}" & "{LP}"
                                BTPRINT.Write(IMP)
                                IMP = Chr(27) & "EZ" & "{PRINT: "
                                coordenada = 0
                            End If
                            salto = salto + 1
                            LecturaF.Text = LecturaF.Text + 1

                        End While
                        ''temporal erick''
                        'If trato.Checked = True Then
                        '    coordenada = coordenada + 30
                        '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                                  " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "             |"
                        'End If
                        ''
                    ElseIf ((tipot.Text = "T") Or (tipot.Text = "T")) Then
                        If tipot.Text = "T" Then
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      EQUIVALENCIA      FECHA CORTE|"
                            'MsgBox(detalle.Text.Length / 12)
                            corte = (detallet.Text.Length / 20)
                            salto = 1
                            LecturaF.Text = 0
                            'MsgBox(corte)
                            While salto <= corte
                                linea = ""
                                coordenada = coordenada + 30
                                linea = detallet.Text.Substring(LecturaF.Text * 20, 20)
                                'MsgBox("linea: " & linea)
                                'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "        " & linea.Substring(6, 6) & "            " & linea.Substring(12, 2) & "/" & linea.Substring(14, 2) & "/" & linea.Substring(16, 4) & "|"
                                salto = salto + 1
                                LecturaF.Text = LecturaF.Text + 1
                            End While
                            ''temporal erick''
                            'If trato.Checked = True Then
                            '    coordenada = coordenada + 30
                            '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "|"
                            'End If
                            ''
                        End If
                        total_detalle = total_unidades
                    ElseIf (tipot.Text = "M") Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADORA      TRACTOR      CARRETAS      O. CORTADORA      O. TRACTOR|"
                        'MsgBox(detalle.Text.Length / 12)
                        corte = (detallet.Text.Length / 21)
                        salto = 1
                        LecturaF.Text = 0
                        'MsgBox(corte)
                        total_detalle = 0
                        While salto <= corte
                            linea = ""
                            coordenada = coordenada + 30
                            linea = detallet.Text.Substring(LecturaF.Text * 21, 21)
                            'MsgBox("linea: " & linea)
                            'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "            " & linea.Substring(3, 3) & "           " & linea.Substring(6, 3) & "           " & linea.Substring(9, 6) & "           " & linea.Substring(15, 6) & "|"
                            ' total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                            salto = salto + 1
                            LecturaF.Text = LecturaF.Text + 1
                        End While
                        total_detalle = total_unidades
                    ElseIf (tipot.Text = "U") Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      CANASTAS |"
                        'MsgBox(detalle.Text.Length / 12)
                        corte = (detallet.Text.Length / 9)
                        salto = 1
                        LecturaF.Text = 0
                        'MsgBox(corte)
                        total_detalle = 0
                        While salto <= corte
                            linea = ""
                            coordenada = coordenada + 30
                            linea = detallet.Text.Substring(LecturaF.Text * 9, 9)
                            'MsgBox("linea: " & linea)
                            'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "            " & linea.Substring(6, 3) & "|"
                            total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                            salto = salto + 1
                            LecturaF.Text = LecturaF.Text + 1
                        End While
                    ElseIf (tipot.Text = "V") Then
                        'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      CANASTAS |"
                        'MsgBox(detalle.Text.Length / 12)
                        corte = (detallet.Text.Length / 12)
                        salto = 1
                        LecturaF.Text = 0
                        'MsgBox(corte)
                        total_detalle = 0
                        While salto <= corte
                            linea = ""
                            'coordenada = coordenada + 30
                            linea = detallet.Text.Substring(LecturaF.Text * 12, 12)
                            'MsgBox("linea: " & linea)
                            'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                            'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "            " & linea.Substring(6, 3) & "|"
                            total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                            TOTAL_SACOS = TOTAL_SACOS + Convert.ToInt32(linea.Substring(9, 3))
                            salto = salto + 1
                            LecturaF.Text = LecturaF.Text + 1
                        End While
                    End If
                    If tipot.Text = "M" Then
                        coordenada = coordenada + 50
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & cortadores.Text & " |"
                    ElseIf tipot.Text = "L" Then
                        coordenada = coordenada + 50
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & numerou1new & " |"
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL QUINTALES:  " & total_detalle & " |"
                        coordenada = coordenada + 30
                        total_tonelada = total_detalle / 20
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL TONELADAS:  " & total_tonelada & " |"
                    Else
                        coordenada = coordenada + 50
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & total_detalle & " |"
                    End If
                    If tipot.Text = "V" Then
                        coordenada = coordenada + 50
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL SACOS: " & TOTAL_SACOS & " |"
                    End If
                    coordenada = coordenada + 50
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ENVIERO    : " & Lpad(usuario.Text, "0", 6) & " |"

                    If (tipot.Text = "L") Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TIPO    : " & texto & " |"
                        coordenada = coordenada + 50
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL CORTADORES:     " & cortadores.Text & "|"
                    End If
                    'SE COMENTA PARA POSTERIORMENTE REALIZAR LAS PRUEBAS CON BASCULA 03/09/2010
                    'If (tipo = "U") Then
                    '    coordenada = coordenada + 50
                    '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTALES:      PESO BRUTO      PESO TARA      PESO NETO" & texto & " |"
                    '    coordenada = coordenada + 30
                    '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |              " & Lpad(total_bruto.ToString, "0", 10) & "      " & Lpad(total_tara.ToString, "0", 9) & "      " & Lpad(total_neto.ToString, "0", 9) & " |"
                    'End If
                    If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "T" Then
                        coordenada = coordenada + 30
                        IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | TOTAL DE CORTADORES INGRESADOS : " & cortadores.Text & "|"
                    End If
                    If tipot.Text = "M" Then
                        Dim TOTAL_CARRETAS As Integer = 0
                        TOTAL_CARRETAS = Convert.ToInt32(cortadores.Text.Trim)
                        '' ''If unidad.TextLength > 0 Then
                        '' ''    TOTAL_CARRETAS = TOTAL_CARRETAS + Convert.ToInt32(unidad.Text)
                        '' ''End If
                        '' ''If unidad2.TextLength > 0 Then
                        '' ''    TOTAL_CARRETAS = TOTAL_CARRETAS + Convert.ToInt32(unidad2.Text)
                        '' ''End If
                        '' ''If unidad3.TextLength > 0 Then
                        '' ''    TOTAL_CARRETAS = TOTAL_CARRETAS + Convert.ToInt32(unidad3.Text)
                        '' ''End If
                        '' ''If unidad4.TextLength > 0 Then
                        '' ''    TOTAL_CARRETAS = TOTAL_CARRETAS + Convert.ToInt32(unidad4.Text)
                        '' ''End If
                        '' ''If unidad5.TextLength > 0 Then
                        '' ''    TOTAL_CARRETAS = TOTAL_CARRETAS + Convert.ToInt32(unidad5.Text)
                        '' ''End If
                        '' ''If unidad6.TextLength > 0 Then
                        '' ''    TOTAL_CARRETAS = TOTAL_CARRETAS + Convert.ToInt32(unidad6.Text)
                        '' ''End If
                        'coordenada = coordenada + 30
                        'IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | TOTAL DE CARRETAS: " & TOTAL_CARRETAS & "|"
                    End If
                    coordenada = coordenada + 50
                    IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | IMPRESION NUMERO : " & IMPRESIONES & "|"
                    coordenada = coordenada + 50
                    IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | UBICACION : " & txtLatitud.Text & ", " & txtLongitud.Text & ", " & txtResult.Text & "|"
                    coordenada = coordenada + 50
                    'Dim algo As Integer = Generado.TextLength
                    'algo = algo
                    Generado.Text = Generado.Text.Remove(93, 3)
                    Generado.Text = Generado.Text.Insert(93, Lpad(total_detalle, "0", 3))
                    If (tipot.Text = "L") Then
                        fe_quema_old = fe_quema.Text
                        'Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(id_contratista.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(pante1, "0", 3) + Lpad(lote1, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(fe_quema_old, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
                        Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(id_contratista.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(pante1, "0", 3) + Lpad(lote1, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
                    End If
                    'Generado.Text = Generado.Text
                    IMP &= "@" & coordenada & ", 0 :PD417, YDIM 6, XDIM 1 COLUMNS 12, SECURITY 3 |" & Generado.Text & "|"
                    'IMP &= "@" & coordenada & ", 150 :UPC-A |" & Generado.Text & "|"
                    IMP &= "}" & "{AHEAD:125}" & "{LP}"
                    BTPRINT.Write(IMP)
                    BTPRINT.Close()
                Catch ex As Exception
                    MsgBox("Error ocacionado por 18" & ex.Message & vbCrLf & "Favor de Reportarlo.")
                End Try
                End If
        Else
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                Dim QUERY = New SqlCeCommand("UPDATE TB_ENVIOS SET IMPRESIONES = " & Convert.ToInt32(IMPRESIONES) & " WHERE ENVIO = " & Convert.ToInt32(NUMERO_REP) & " AND SERIE = '" & Convert.ToString(serie_preparada) & "';", CONN)
                '"INSERT INTO TB_PILOTOS_TRANSPORTISTA (ID_TRANSPORTISTA, ID_PILOTO, ID_PILOTO_ORIGINAL, ID_PERIODO_COSECHA, ESTADO) VALUES (" & Convert.ToInt32(campo1) & ", " & Convert.ToInt32(campo2) & ", " & Convert.ToInt32(campo4) & ", " & Convert.ToInt32(campo5) & ", '" + Convert.ToString(campo3) + "');
                'Dim dr As SqlCeDataReader = Nothing
                Dim REGISTROS As Integer
                Try
                    CONN.Open()
                    If CONN.State = Data.ConnectionState.Open Then
                        REGISTROS = QUERY.ExecuteNonQuery
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por17 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
                CONN.Close()
                'IMPRESIONES = 1 'IMPRESIONES
                'IMPRESIONES2 = IMPRESIONES2 + 1
                f_imprimir_envio()
                bandera = 1
        End If
        IMPRESIONES = IMPRESIONES + 1
        IMPRESIONES2 = IMPRESIONES2 + 1
    End Sub
    Private Sub f_grabar_envio()
        If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
            cuenta_unadas()
        ElseIf (tipot.Text = "M") Or (tipot.Text = "L") Then
            cuenta_carretas()
        End If
        ' PuertoSerial.Close()
        Dim fecha1 As DateTime = Nothing
        Dim fecha2 As DateTime = Nothing
        Dim fecha3 As DateTime = Nothing
        Dim fecha4 As DateTime = Nothing
        Dim fecha5 As DateTime = Nothing
        Dim fecha6 As DateTime = Nothing
        Dim fecha7 As DateTime = Nothing
        Dim numeroa As Integer = 0
        Dim numerol1 As Integer = 0
        Dim numerol2 As Integer = 0
        Dim numerol3 As Integer = 0
        Dim numerol4 As Integer = 0
        Dim numeror As Integer = 0
        Dim numeroz As Integer = 0
        Dim numerot As Integer = 0
        Dim numerov As Integer = 0
        Dim numerop As Integer = 0
        Dim numeroe As Integer = 0
        Dim numerope As Integer = 0
        Dim numeroen As Integer = 0
        Dim numeroco As Integer = 0
        Dim numeropl As Integer = 0
        Dim numeroc As Integer = 0
        Dim numerou1 As Integer = 0
        Dim numerou2 As Integer = 0
        Dim numerou3 As Integer = 0
        Dim numerou4 As Integer = 0
        Dim numeroim As Integer = 0
        Dim numeroal As Integer = 0
        Dim numerotr As Integer = 0
        Dim numerooa As Integer = 0
        Dim numeroot As Integer = 0
        Dim numeroti As Integer = 0
        Dim numeroorden As Integer = 0 'agregado erick
        Dim numerocorte As Integer = 0 'agregado erick
        Dim v_serie_croquis As String
        Dim v_placa As String = Nothing
        Dim testogru As String = Nothing
        Dim testoti As String = Nothing
        Dim testose As String = Nothing
        Dim numerofi As Integer = 0
        Dim numerofre As Integer = 0
        Dim numerop1 As Integer = 0
        Dim numerop2 As Integer = 0
        Dim numerop3 As Integer = 0
        Dim numerop4 As Integer = 0
        Dim validaf2 As Integer = 0
        Dim validaf3 As Integer = 0
        Dim validaf4 As Integer = 0
        Dim validaf5 As Integer = 0
        Dim validaf6 As Integer = 0
        Dim VALIDAFT As DateTime

        fechaq1 = Lpad(fe_quema.Text, "0", 8)
        fechaq2 = Lpad(quema2.Text, "0", 8)
        fechaq3 = Lpad(quema3.Text, "0", 8)
        fechaq4 = Lpad(quema4.Text, "0", 8)
        fechaq5 = Lpad(quema5.Text, "0", 8)
        fechaq6 = Lpad(quema6.Text, "0", 8)
        horaq1 = Lpad(Ho_quema.Text, "0", 4)
        horaq2 = Lpad(hora2.Text, "0", 4)
        horaq3 = Lpad(hora3.Text, "0", 4)
        horaq4 = Lpad(hora4.Text, "0", 4)
        horaq5 = Lpad(hora5.Text, "0", 4)
        horaq6 = Lpad(hora6.Text, "0", 4)

        If tipot.Text <> "U" And tipot.Text <> "V" Then
            zona.Text = Lizona.Items.Item(Lizona.SelectedIndex)
            If txtLote.Text.Length < 0 Then
                lote1 = ""
            Else
                lote1 = txtLote.Text
            End If
            'If lilo1.SelectedIndex < 0 Then
            'lote1 = ""
            'Else
            '   lote1 = lilo1.Items.Item(lilo1.SelectedIndex).ToString()
            'End If
            If lilo2.SelectedIndex < 0 Then
                lote2 = ""
            Else
                lote2 = lilo2.Items.Item(lilo2.SelectedIndex).ToString()
            End If
            If lilo3.SelectedIndex < 0 Then
                lote3 = ""
            Else
                lote3 = lilo3.Items.Item(lilo3.SelectedIndex).ToString()
            End If
            If lilo4.SelectedIndex < 0 Then
                lote4 = ""
            Else
                lote4 = lilo4.Items.Item(lilo4.SelectedIndex).ToString()
            End If
            If lilo5.SelectedIndex < 0 Then
                lote5 = ""
            Else
                lote5 = lilo5.Items.Item(lilo5.SelectedIndex).ToString()
            End If
            If lilo6.SelectedIndex < 0 Then
                lote6 = ""
            Else
                lote6 = lilo6.Items.Item(lilo6.SelectedIndex).ToString()
            End If
            If txtPante.Text.Length < 0 Then
                pante1 = ""
            Else
                pante1 = txtPante.Text
            End If
            'If lipa1.SelectedIndex < 0 Then
            'pante1 = ""
            'Else
            '   pante1 = lipa1.Items.Item(lipa1.SelectedIndex).ToString()
            '-End If
            If lipa2.SelectedIndex < 0 Then
                pante2 = ""
            Else
                pante2 = lipa2.Items.Item(lipa2.SelectedIndex).ToString()
            End If
            If lipa3.SelectedIndex < 0 Then
                pante3 = ""
            Else
                pante3 = lipa3.Items.Item(lipa3.SelectedIndex).ToString()
            End If
            If lipa4.SelectedIndex < 0 Then
                pante4 = ""
            Else
                pante4 = lipa4.Items.Item(lipa4.SelectedIndex).ToString()
            End If
            If lipa5.SelectedIndex < 0 Then
                pante5 = ""
            Else
                pante5 = lipa5.Items.Item(lipa5.SelectedIndex).ToString()
            End If
            If lipa6.SelectedIndex < 0 Then
                pante6 = ""
            Else
                pante6 = lipa6.Items.Item(lipa6.SelectedIndex).ToString()
            End If
        End If

        If fecturno.Text.Length > 0 Then
            VALIDAFT = Convert.ToDateTime(fecturno.Text.Substring(2, 2) + "/" + fecturno.Text.Substring(0, 2) + "/" + fecturno.Text.Substring(4, 4))
            '' VALIDAFT = Convert.ToDateTime(fecturno.Text.Substring(6, 2) + "/" + fecturno.Text.Substring(4, 2) + "/" + fecturno.Text.Substring(0, 4)) '+ " " + fecha_turno.Substring(8, 2) + ":" + fecha_turno.Substring(10, 2)
            'VALIDAFT = Convert.ToDateTime(fecturno.Text.Substring(0, 2) + "/" + fecturno.Text.Substring(2, 2) + "/" + fecturno.Text.Substring(4, 4))
        Else
            VALIDAFT = Convert.ToDateTime(Now)
        End If
        '  If fecha_env.Length > 0 Then
        '' fecha1 = Convert.ToDateTime(fecha_env.Substring(2, 2) + "/" + fecha_env.Substring(0, 2) + "/" + fecha_env.Substring(4, 4))
        'fecha1 = Convert.ToDateTime(fecha_env.Substring(6, 2) + "/" + fecha_env.Substring(4, 2) + "/" + fecha_env.Substring(0, 4)) ' tenia hasta 14/01/2013
        ''fecha1 = Convert.ToDateTime(fecha_env.Substring(0, 2) + "/" + fecha_env.Substring(2, 2) + "/" + fecha_env.Substring(6, 4))
        'Else
        '   fecha1 = Convert.ToDateTime(Now)
        'End If
        If fechaq1 <> "00000000" And horaq1 <> "0000" Then
            fecha2 = Convert.ToDateTime(fechaq1.Substring(2, 2) + "/" + fechaq1.Substring(0, 2) + "/" + fechaq1.Substring(4, 4) + " " + horaq1.Substring(0, 2) + ":" + horaq1.Substring(2, 2))
            'fecha2 = Convert.ToDateTime(fechaq1.Substring(6, 2) + "/" + fechaq1.Substring(4, 2) + "/" + fechaq1.Substring(0, 4) + " " + horaq1.Substring(0, 2) + ":" + horaq1.Substring(2, 2))
        Else
            fecha2 = Convert.ToDateTime(Now)
        End If
        If fechaq2 <> "00000000" And horaq2 <> "0000" Then
            fecha3 = Convert.ToDateTime(fechaq2.Substring(2, 2) + "/" + fechaq2.Substring(0, 2) + "/" + fechaq2.Substring(4, 4) + " " + horaq2.Substring(0, 2) + ":" + horaq2.Substring(2, 2))
            'fecha3 = Convert.ToDateTime(fechaq2.Substring(6, 2) + "/" + fechaq2.Substring(4, 2) + "/" + fechaq2.Substring(0, 4) + " " + horaq2.Substring(0, 2) + ":" + horaq2.Substring(2, 2))
        Else
            fecha3 = Convert.ToDateTime(Now)
            validaf2 = 1

        End If
        If fechaq3 <> "00000000" And horaq3 <> "0000" Then
            'fecha4 = Convert.ToDateTime(fechaq3.Substring(2, 2) + "/" + fechaq3.Substring(0, 2) + "/" + fechaq3.Substring(4, 4) + " " + horaq3.Substring(0, 2) + ":" + horaq3.Substring(2, 2))
            fecha4 = Convert.ToDateTime(fechaq3.Substring(6, 2) + "/" + fechaq3.Substring(4, 2) + "/" + fechaq3.Substring(0, 4) + " " + horaq3.Substring(0, 2) + ":" + horaq3.Substring(2, 2))
        Else
            fecha4 = Convert.ToDateTime(Now)
            validaf3 = 1
        End If
        If fechaq4 <> "00000000" And horaq4 <> "0000" Then
            'fecha5 = Convert.ToDateTime(fechaq4.Substring(2, 2) + "/" + fechaq4.Substring(0, 2) + "/" + fechaq4.Substring(4, 4) + " " + horaq4.Substring(0, 2) + ":" + horaq4.Substring(2, 2))
            fecha5 = Convert.ToDateTime(fechaq4.Substring(6, 2) + "/" + fechaq4.Substring(4, 2) + "/" + fechaq4.Substring(0, 4) + " " + horaq4.Substring(0, 2) + ":" + horaq4.Substring(2, 2))
        Else
            fecha5 = Convert.ToDateTime(Now)
            validaf4 = 1
        End If
        If fechaq5 <> "00000000" And horaq5 <> "0000" Then
            'fecha6 = Convert.ToDateTime(fechaq5.Substring(2, 2) + "/" + fechaq5.Substring(0, 2) + "/" + fechaq5.Substring(4, 4) + " " + horaq5.Substring(0, 2) + ":" + horaq5.Substring(2, 2))
            fecha6 = Convert.ToDateTime(fechaq5.Substring(6, 2) + "/" + fechaq5.Substring(4, 2) + "/" + fechaq5.Substring(0, 4) + " " + horaq5.Substring(0, 2) + ":" + horaq5.Substring(2, 2))
        Else
            fecha6 = Convert.ToDateTime(Now)
            validaf5 = 1
        End If
        If fechaq6 <> "00000000" And horaq6 <> "0000" Then
            'fecha7 = Convert.ToDateTime(fechaq6.Substring(2, 2) + "/" + fechaq6.Substring(0, 2) + "/" + fechaq6.Substring(4, 4) + " " + horaq6.Substring(0, 2) + ":" + horaq6.Substring(2, 2))
            fecha7 = Convert.ToDateTime(fechaq6.Substring(6, 2) + "/" + fechaq6.Substring(4, 2) + "/" + fechaq6.Substring(0, 4) + " " + horaq6.Substring(0, 2) + ":" + horaq6.Substring(2, 2))
        Else
            fecha7 = Convert.ToDateTime(Now)
            validaf6 = 1
        End If
        If numero_archivo > 0 Then
            numeroa = Convert.ToInt32(numero_archivo)
        Else
            numeroa = 0
        End If
        If Id_finca.Text.Length > 0 Then
            numerofi = Convert.ToInt32(Id_finca.Text)
        Else
            numerofi = 0
        End If
        If Id_Frente.Text.Length > 0 Then
            numerofre = Convert.ToInt32(Id_Frente.Text)
        Else
            numerofre = 0
        End If
        If pante1.Length > 0 Then
            numerop1 = Convert.ToInt32(pante1)
        Else
            numerop1 = 0
        End If
        If pante2.Length > 0 Then
            numerop2 = Convert.ToInt32(pante2)
        Else
            numerop2 = 0
        End If
        If pante3.Length > 0 Then
            numerop3 = Convert.ToInt32(pante3)
        Else
            numerop3 = 0
        End If
        If pante4.Length > 0 Then
            numerop4 = Convert.ToInt32(pante4)
        Else
            numerop4 = 0
        End If
        If lote1.Length > 0 Then
            numerol1 = Convert.ToInt32(lote1)
        Else
            numerol1 = 0
        End If
        If lote2.Length > 0 Then
            numerol2 = Convert.ToInt32(lote2)
        Else
            numerol2 = 0
        End If
        If lote3.Length > 0 Then
            numerol3 = Convert.ToInt32(lote3)
        Else
            numerol3 = 0
        End If
        If lote4.Length > 0 Then
            numerol4 = Convert.ToInt32(lote4)
        Else
            numerol4 = 0
        End If
        If id_ruta.Text.Length > 0 Then
            numeror = Convert.ToInt32(id_ruta.Text)
        Else
            numeror = 0
        End If
        If Lizona.SelectedIndex >= 0 Then
            'zona.Text.Length > 0 Then
            numeroz = Convert.ToInt32(Lizona.Items.Item(Lizona.SelectedIndex()))
        Else
            numeroz = 2
        End If
        If trans.Text.Length > 0 Then
            numerot = Convert.ToInt32(trans.Text)
        Else
            numerot = 0
        End If
        If vehi.Text.Length > 0 Then
            numerov = Convert.ToInt32(vehi.Text)
        Else
            numerov = 0
        End If
        If pilo.Text.Length > 0 Then
            numerop = Convert.ToInt32(pilo.Text)
        Else
            numerop = 0
        End If
        If Empresa.Text.Length > 0 Then
            numeroe = Convert.ToInt32(Empresa.Text)
        Else
            numeroe = 0
        End If
        If peri.Text.Length > 0 Then
            numerope = Convert.ToInt32(peri.Text)
        Else
            numerope = 0
        End If
        If usuario.Text.Length > 0 Then
            numeroen = Convert.ToInt32(usuario.Text)
        Else
            numeroen = 0
        End If
        If id_contratista.Text.Length > 0 Then
            numeroco = Convert.ToInt32(id_contratista.Text)
        Else
            numeroco = 0
        End If
        If plata.Text.Length > 0 Then
            numeropl = Convert.ToInt32(plata.Text)
        Else
            numeropl = 0
        End If
        If cole.Text.Length > 0 Then
            numeroc = Convert.ToInt32(cole.Text)
        Else
            numeroc = 0
        End If
        If unidad.Text.Length > 0 Then
            'numerou1 = Convert.ToInt32(unidad.Text)
            ''numerou1 = lv_unidad
            If (tipot.Text = "L") Then
                'numerou1 = cortadores.Text
                numerou1 = unidad.Text 'lv_unidad
                numerou1new = unidad.Text
            Else
                numerou1 = lv_unidad
            End If
        Else
            numerou1 = 0
        End If
        If unidad2.Text.Length > 0 Then
            numerou2 = Convert.ToInt32(unidad2.Text)
        Else
            numerou2 = 0
        End If
        If unidad3.Text.Length > 0 Then
            numerou3 = Convert.ToInt32(unidad3.Text)
        Else
            numerou3 = 0
        End If
        If unidad4.Text.Length > 0 Then
            numerou4 = Convert.ToInt32(unidad4.Text)
        Else
            numerou4 = 0
        End If
        If IMPRESIONES >= 1 Then
            numeroim = Convert.ToInt32(IMPRESIONES)
        Else
            numeroim = 0
        End If
        If ALZ.Text.Length > 0 Then
            numeroal = Convert.ToInt32(ALZ.Text)
        Else
            numeroal = 0
        End If
        If TRA.Text.Length > 0 Then
            numerotr = Convert.ToInt32(TRA.Text)
        Else
            numerotr = 0
        End If
        If OPA.Text.Length > 0 Then
            numerooa = Convert.ToInt32(OPA.Text)
        Else
            numerooa = 0
        End If
        If OPT.Text.Length > 0 Then
            numeroot = Convert.ToInt32(OPT.Text)
        Else
            numeroot = 0
        End If
        If Nboleta.Text.Length > 0 Then
            numeroti = Convert.ToInt32(Nboleta.Text)
        Else
            numeroti = 0
        End If
        If grupo.Text.Length > 0 Then
            testogru = Convert.ToString(grupo.Text)
        Else
            testogru = Nothing
        End If
        If tipot.Text.Length > 0 Then
            testoti = Convert.ToString(tipot.Text)
        Else
            testoti = Nothing
        End If
        If serie_preparada.Length > 0 Then
            testose = Convert.ToString(serie_preparada)
        Else
            testose = Nothing
        End If
        'erick orden if
        If ocorte.Text.Length > 0 Then
            numeroorden = Convert.ToInt32(ocorte.Text)
        Else
            numeroorden = 0
        End If
        If ocorte.Text = Nothing Then
            numeroorden = 0
        End If
        'erick orden end if         ocorte.Text
        'erick croquis if
        If Croquis.Text.Length > 0 Then
            numerocorte = Convert.ToInt32(Croquis.Text)
        Else
            numerocorte = 0
        End If
        If Croquis.Text = Nothing Then
            numerocorte = 0
        End If
        If SerieCroquis.Text.Length > 0 Then
            v_serie_croquis = Convert.ToString(SerieCroquis.Text)
        Else
            v_serie_croquis = "0"
        End If
        If SerieCroquis.Text = Nothing Then
            v_serie_croquis = "0"
        End If
        '----------------
        If Manual.CheckState = Windows.Forms.CheckState.Unchecked Then
            v_placa = scanner.Text.Substring(2, 6)
            'v_placa = Convert.ToString(txtPlacas.Text.Substring(0, 3)) + Convert.ToString(txtPlacas.Text.Substring(4, 3))
        ElseIf Manual.CheckState = Windows.Forms.CheckState.Checked Then
            v_placa = txtPLaca.Text
        End If
        '-------------------
        'erick croquis end if
        ''FECHA_ENVIO, FECHA_QUEMA1, FECHA_QUEMA2, FECHA_QUEMA3, FECHA_QUEMA4, ", " & fecha1 & ", " & fecha2 & ", " & fecha3 & ", " & fecha4 & ", " & fecha5 & 
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim QUERY = New SqlCeCommand()
        Dim QUERY2 = New SqlCeCommand()
        If validaf2 = 1 And validaf3 = 1 And validaf4 = 1 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO,  PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ", '" + v_placa + "', '" + v_serie_croquis + "');", CONN)
            'QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presenta.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ");", CONN)
            'QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("ddMMyyyy HH:mm") + "', '" + fecha2.ToString("ddMMyyyy HH:mm") + "', '" + Now.ToString("ddMMyyyy HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("ddMMyyyy HH:mm") + "', '" + presenta.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ");", CONN)
        ElseIf validaf2 = 1 And validaf3 = 1 And validaf4 = 0 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA4, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE,FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha5.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        ElseIf validaf2 = 1 And validaf3 = 0 And validaf4 = 1 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA3, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha4.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        ElseIf validaf2 = 0 And validaf3 = 1 And validaf4 = 1 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA2, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha3.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        ElseIf validaf2 = 1 And validaf3 = 0 And validaf4 = 0 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA3, FECHA_QUEMA4, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha4.ToString("yyyyMMdd HH:mm") + "', '" + fecha5.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        ElseIf validaf2 = 0 And validaf3 = 1 And validaf4 = 0 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA2, FECHA_QUEMA4, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha3.ToString("yyyyMMdd HH:mm") + "', '" + fecha5.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        ElseIf validaf2 = 0 And validaf3 = 0 And validaf4 = 1 Then
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA2, FECHA_QUEMA3, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha3.ToString("yyyyMMdd HH:mm") + "', '" + fecha4.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        Else
            QUERY = New SqlCeCommand("INSERT INTO TB_ENVIOS (ENVIO,  FINCA, FRENTE, PANTE1, PANTE2, PANTE3, PANTE4, LOTE1, LOTE2, LOTE3, LOTE4,  RUTA, ZONA, TRANSPORTISTA, VEHICULO, PILOTO, EMPRESA, PERIODO_COSECHA, ENVIERO, CONTRATISTA, PLATAFORMA, COLERA, UNIDAD1, UNIDAD2, UNIDAD3, UNIDAD4, IMPRESIONES, ALZADOR, TRACTOR, OP_ALZADOR, OP_TRACTOR, FECHA_ENVIO, FECHA_QUEMA1, FECHA_DESPACHO, FECHA_QUEMA2, FECHA_QUEMA3, FECHA_QUEMA4, BOLETA_TRANSPORTE, TURNO, TIPO, SERIE, FECHA_TURNO, PRESENTA, LATITUD, LONGITUD, ESTADO_FINCA, CROQUIS, ORDEN_CORTE, PLACAS, SERIE_CROQUIS) VALUES  (" & NUMERO_REP & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & IMPRESIONES & ", " & numeroal & ", " & numerotr & ", " & numerooa & ", " & numeroot & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha2.ToString("yyyyMMdd HH:mm") + "', '" + Now.ToString("yyyyMMdd HH:mm") + "', '" + fecha3.ToString("yyyyMMdd HH:mm") + "', '" + fecha4.ToString("yyyyMMdd HH:mm") + "', '" + fecha5.ToString("yyyyMMdd HH:mm") + "', " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "', '" + VALIDAFT.ToString("yyyyMMdd HH:mm") + "', '" + presentanew.Text.Substring(0, 1) + "', '" + Replace(txtLatitud.Text, Chr(39), "|") + "', '" + Replace(txtLongitud.Text, Chr(39), "|") + "', '" + txtResult.Text.Substring(0, 1) + "', " & numerocorte & ", " & numeroorden & ",'" + v_placa + "','" + v_serie_croquis + "');", CONN)
        End If
        Dim REGISTROS As Integer
        Try
            CONN.Open()
            If CONN.State = Data.ConnectionState.Open Then
                REGISTROS = QUERY.ExecuteNonQuery
            End If
        Catch ex As Exception
            MsgBox("NO se guardo el envio! salga y vuelva a realizarlo" & ex.Message & vbCrLf & _
                        "Reportarlo, no dar el envio a piloto.")
        End Try
        CONN.Close()
        Dim CANTIDAD As Integer = 0
        Dim CONN2 = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASETURNO)
        Dim query3 = New SqlCeCommand("Select turno from tb_turno where estado = 'A'", CONN2)
        Dim dr3 As SqlCeDataReader = Nothing
        Dim turno_abierto As Integer = 0
        CONN2.Open()
        dr3 = query3.ExecuteReader()
        While dr3.Read
            turno_abierto = Convert.ToInt32(dr3(0).ToString)
        End While
        'CONN2.Close()
        QUERY2 = New SqlCeCommand("INSERT INTO TB_DETALLE_TURNO(TURNO, SERIE, REPORTE, FECHA_ENVIO, ID_TRANSPORTISTA, ID_VEHICULO, ID_FINCA) VALUES (" & turno_abierto & ", '" + testose + "', " & NUMERO_REP & ", '" + Now.ToString("yyyyMMdd HH:mm") + "', " & numerot & ", " & numerov & ", " & numerofi & ")", CONN2)
        Try
            'CONN2.Open()
            CANTIDAD = QUERY2.ExecuteNonQuery

        Catch ex As Exception
            MsgBox("NO se guardo correctamente " & ex.Message & vbCrLf & "Reportarlo, no dar el envio al piloto.")
        End Try
        CONN2.Close()
        'MsgBox(QUERY.CommandText)
        '(" & Convert.ToInt32(numero_archivo) & ", " & Convert.ToInt32(finca) & ", " & Convert.ToInt32(frente) & ", " & Convert.ToInt32(pante1) & ", " & Convert.ToInt32(pante2) & ", " & Convert.ToInt32(pante3) & ", " & Convert.ToInt32(pante4) & ", " & Convert.ToInt32(lote1) & ", " & Convert.ToInt32(lote2) & ", " & Convert.ToInt32(lote3) & ", " & Convert.ToInt32(lote4) & ", " & Convert.ToInt32(ruta) & ", " & Convert.ToInt32(zona) & ", " & Convert.ToInt32(trans) & ", " & Convert.ToInt32(vehi) & ", " & Convert.ToInt32(pilo) & ", " & Convert.ToInt32(empresa) & ", " & Convert.ToInt32(peri) & ", " & Convert.ToInt32(enviero) & ", " & Convert.ToInt32(contratista) & ", " & Convert.ToInt32(plata) & ", " & Convert.ToInt32(cole) & ", " & Convert.ToInt32(unidad1) & ", " & Convert.ToInt32(unidad2) & ", " & Convert.ToInt32(unidad3) & ", " & Convert.ToInt32(unidad4) & ", " & Convert.ToInt32(1) & ", " & Convert.ToInt32(alzador) & ", " & Convert.ToInt32(tractor) & ", " & Convert.ToInt32(opera_alz) & ", " & Convert.ToInt32(opera_tra) & ", " & Convert.ToInt32(ticket) & ", '" + Convert.ToString(grupo) + "', '" + Convert.ToString(tipo) + "', '" + Convert.ToString(serie_preparada) + "');", CONN)
        '"INSERT INTO TB_PILOTOS_TRANSPORTISTA (ID_TRANSPORTISTA, ID_PILOTO, ID_PILOTO_ORIGINAL, ID_PERIODO_COSECHA, ESTADO) VALUES (" & Convert.ToInt32(campo1) & ", " & Convert.ToInt32(campo2) & ", " & Convert.ToInt32(campo4) & ", " & Convert.ToInt32(campo5) & ", '" + Convert.ToString(campo3) + "');
        'Dim dr As SqlCeDataReader = Nothing

        If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "L" Then
            If detallet.TextLength > 0 Then
                corte = (detallet.Text.Length / 35)
                salto = 1
                LecturaF.Text = 0
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                    Dim F As Integer = Convert.ToInt32(linea.Substring(0, 3))
                    Dim P As Integer = Convert.ToInt32(linea.Substring(3, 3))
                    Dim C As Integer = Convert.ToInt32(linea.Substring(6, 6))
                    Dim U As Integer = Convert.ToInt32(linea.Substring(12, 3))
                    Dim FC As DateTime = Nothing
                    If linea.Substring(15, 8) = "00000000" Then
                        FC = Convert.ToDateTime(Nothing)
                    Else
                        FC = Convert.ToDateTime(linea.Substring(17, 2) + "/" + linea.Substring(15, 2) + "/" + linea.Substring(19, 4))
                    End If
                    Dim EQ As String = linea.Substring(23, 6)
                    Dim con As Integer = Convert.ToInt32(linea.Substring(29, 6))
                    CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE, FILA, POSICION, CORTADOR, UNIDAD, FECHA_CORTE,  EQUIVALENCIA, SERIE, TIPO, CONTRATISTA) VALUES  (" & NUMERO_REP & ", " & salto & ", " & F & ", " & P & ", " & C & ", " & U & ", '" + FC.ToString("dd/MM/yyyy") + "', '" + EQ + "', '" + serie_preparada + "', '" + tipot.Text + "', " & con & " );", CONN)
                    Try
                        CONN.Open()
                        If CONN.State = Data.ConnectionState.Open Then
                            REGISTROS = QUERY.ExecuteNonQuery
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por8 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                    End Try
                    CONN.Close()
                    'f_imprimir_envio()
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                f_imprimir_envio()
            End If
            If trato.Checked = True Then
                salto = 1
                CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE,FECHA_CORTE, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", '" + fecha_corte.Text + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                Try
                    CONN.Open()
                    If CONN.State = Data.ConnectionState.Open Then
                        REGISTROS = QUERY.ExecuteNonQuery
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por9 " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
                End Try
                CONN.Close()
                f_imprimir_envio()
            End If
        ElseIf tipot.Text = "M" Then
            If detallet.TextLength > 0 Then
                corte = (detallet.Text.Length / 21)
                salto = 1
                LecturaF.Text = 0
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    linea = detallet.Text.Substring(LecturaF.Text * 21, 21)
                    Dim C As Integer = Convert.ToInt32(linea.Substring(0, 3))
                    Dim T As Integer = Convert.ToInt32(linea.Substring(3, 3))
                    Dim CA As Integer = Convert.ToInt32(linea.Substring(6, 3))
                    Dim OC As Integer = Convert.ToInt32(linea.Substring(9, 6))
                    Dim OT As Integer = Convert.ToInt32(linea.Substring(15, 6))
                    CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE, ALZADORA, TRACTOR, CARRETAS, CORTADOR, OPERADOR_TRA, TIPO, SERIE) VALUES (" & NUMERO_REP & ", " & salto & ", " & C & ", " & T & ", " & CA & ", " & OC & ", " & OT & ", '" + tipot.Text + "', '" + serie_preparada + "');", CONN)
                    Try
                        CONN.Open()
                        If CONN.State = Data.ConnectionState.Open Then
                            REGISTROS = QUERY.ExecuteNonQuery
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por10 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                    End Try
                    CONN.Close()
                    'f_imprimir_envio()
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                f_imprimir_envio()
            End If
            '-----------------------------------------------------------------
            '------------------------------------------------------------------
            'CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NOMBREBD)
            'QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO (ENVIO, DETALLE, ALZADORA, TRACTOR, CARRETAS, CORTADOR, OPERADOR_TRA, OPERADOR_ALZ, SERIE, TIPO) VALUES  (" & numeroa & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & impresiones & ", " & numeroal & ", " & numerot & ", " & numerooa & ", " & numeroot & ", " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "');", CONN)
            'Try
            '    CONN.Open()
            '    If CONN.State = Data.ConnectionState.Open Then
            '        REGISTROS = QUERY.ExecuteNonQuery
            '    End If
            'Catch ex As Exception
            '    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
            '            "Favor de reportarlo.")
            'End Try
            'CONN.Close()
        ElseIf tipot.Text = "T" Then
            If detallet.TextLength > 0 Then
                corte = (detallet.Text.Length / 20)
                salto = 1
                LecturaF.Text = 0
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    linea = detallet.Text.Substring(LecturaF.Text * 20, 20)
                    Dim C As Integer = Convert.ToInt32(linea.Substring(0, 6))
                    'Dim E As Integer = Convert.ToInt32(linea.Substring(6, 6))
                    'Dim FC As Date = Convert.ToDateTime(linea.Substring(12, 2) + "/" + linea.Substring(14, 2) + "/" + linea.Substring(16, 4))
                    Dim EQ As String = Convert.ToString(linea.Substring(6, 6))
                    Dim FC As Date = Nothing
                    If linea.Substring(12, 8) = "00000000" Then
                        FC = Convert.ToDateTime(Nothing)
                    Else
                        FC = Convert.ToDateTime(linea.Substring(14, 2) + "/" + linea.Substring(12, 2) + "/" + linea.Substring(16, 4))
                    End If
                    CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE, CORTADOR, FECHA_CORTE,  EQUIVALENCIA, SERIE, TIPO) VALUES (" & NUMERO_REP & ", " & salto & ", " & C & ", '" + FC.ToString("dd/MM/yyyy") + "', '" + EQ + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                    Try
                        CONN.Open()
                        If CONN.State = Data.ConnectionState.Open Then
                            REGISTROS = QUERY.ExecuteNonQuery
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por11 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                    End Try
                    CONN.Close()
                    'f_imprimir_envio()
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                f_imprimir_envio()
            End If
            If trato.Checked = True Then
                salto = 1
                CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE,FECHA_CORTE, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", '" + fecha_corte.Text + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                Try
                    CONN.Open()
                    If CONN.State = Data.ConnectionState.Open Then
                        REGISTROS = QUERY.ExecuteNonQuery
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por12 " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
                End Try
                CONN.Close()
                f_imprimir_envio()
            End If
            ' ElseIf tipot.Text = "L" Then
            'If detallet.TextLength > 0 Then
            '    corte = (detallet.Text.Length / 20)
            '    salto = 1
            '    LecturaF.Text = 0
            '    total_detalle = 0
            '    While salto <= corte
            '        linea = ""
            '        linea = detallet.Text.Substring(LecturaF.Text * 20, 20)
            '        Dim C As Integer = Convert.ToInt32(linea.Substring(0, 6))
            '        Dim EQ As String = Convert.ToString(linea.Substring(6, 6))
            '        Dim FC As Date = Nothing
            '        If linea.Substring(12, 8) = "00000000" Then
            '            FC = Convert.ToDateTime(Nothing)
            '        Else
            '            FC = Convert.ToDateTime(linea.Substring(14, 2) + "/" + linea.Substring(12, 2) + "/" + linea.Substring(16, 4))
            '        End If
            '        CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            '        QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE, CORTADOR, FECHA_CORTE,  EQUIVALENCIA, SERIE, TIPO) VALUES (" & NUMERO_REP & ", " & salto & ", " & C & ", '" + FC.ToString("dd/MM/yyyy") + "', '" + EQ + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
            '        Try
            '            CONN.Open()
            '            If CONN.State = Data.ConnectionState.Open Then
            '                REGISTROS = QUERY.ExecuteNonQuery
            '            End If
            '        Catch ex As Exception
            '            MsgBox("Error ocasionado por11 " & ex.Message & vbCrLf & _
            '                    "Favor de reportarlo.")
            '        End Try
            '        CONN.Close()
            '        f_imprimir_envio()
            '        salto = salto + 1
            '        LecturaF.Text = LecturaF.Text + 1
            '    End While
            'End If
            'If trato.Checked = True Then
            '    salto = 1
            '    CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            '    QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE,FECHA_CORTE, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", '" + fecha_corte.Text + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
            '    Try
            '        CONN.Open()
            '        If CONN.State = Data.ConnectionState.Open Then
            '            REGISTROS = QUERY.ExecuteNonQuery
            '        End If
            '    Catch ex As Exception
            '        MsgBox("Error ocasionado por12 " & ex.Message & vbCrLf & _
            '                "Favor de reportarlo.")
            '    End Try
            '    CONN.Close()
            ' f_imprimir_envio()
            '---------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------
            'CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NOMBREBD)
            'QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO (ENVIO, DETALLE, CORTADOR, FECHA_CORTE, EQUIVALENCIA, SERIE, TIPO) VALUES  (" & numeroa & ", " & numerofi & ", " & numerofre & ", " & numerop1 & ", " & numerop2 & ", " & numerop3 & ", " & numerop4 & ", " & numerol1 & ", " & numerol2 & ", " & numerol3 & ", " & numerol4 & ", " & numeror & ", " & numeroz & ", " & numerot & ", " & numerov & ", " & numerop & ", " & numeroe & ", " & numerope & ", " & numeroen & ", " & numeroco & ", " & numeropl & ", " & numeroc & ", " & numerou1 & ", " & numerou2 & ", " & numerou3 & ", " & numerou4 & ", " & impresiones & ", " & numeroal & ", " & numerot & ", " & numerooa & ", " & numeroot & ", " & numeroti & ", '" + testogru + "', '" + testoti + "', '" + testose + "');", CONN)
            'Try
            '    CONN.Open()
            '    If CONN.State = Data.ConnectionState.Open Then
            '        REGISTROS = QUERY.ExecuteNonQuery
            '    End If
            'Catch ex As Exception
            '    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
            '            "Favor de reportarlo.")
            'End Try
            'CONN.Close()
        ElseIf tipot.Text = "U" Then
            If detallet.TextLength > 0 Then
                corte = (detallet.Text.Length / 9)
                salto = 1
                LecturaF.Text = 0
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    linea = detallet.Text.Substring(LecturaF.Text * 9, 9)
                    Dim C As Integer = Convert.ToInt32(linea.Substring(0, 6))
                    Dim U As Integer = Convert.ToInt32(linea.Substring(6, 3))
                    CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE, CORTADOR, UNIDAD, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", " & C & ", " & U & ", '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                    Try
                        CONN.Open()
                        If CONN.State = Data.ConnectionState.Open Then
                            REGISTROS = QUERY.ExecuteNonQuery
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por13 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                    End Try
                    CONN.Close()
                    'f_imprimir_envio()
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                f_imprimir_envio()
            End If
            If trato.Checked = True Then
                salto = 1
                CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE,FECHA_CORTE, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", '" + fecha_corte.Text + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                Try
                    CONN.Open()
                    If CONN.State = Data.ConnectionState.Open Then
                        REGISTROS = QUERY.ExecuteNonQuery
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por14 " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
                End Try
                CONN.Close()
                f_imprimir_envio()
            End If
        ElseIf tipot.Text = "V" Then
            If detallet.TextLength > 0 Then
                corte = (detallet.Text.Length / 12)
                salto = 1
                LecturaF.Text = 0
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    linea = detallet.Text.Substring(LecturaF.Text * 12, 12)
                    Dim C As Integer = Convert.ToInt32(linea.Substring(0, 6))
                    Dim U As Integer = Convert.ToInt32(linea.Substring(6, 3))
                    Dim S As Integer = Convert.ToInt32(linea.Substring(9, 3))
                    CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE, CORTADOR, UNIDAD, POSICION, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", " & C & ", " & U & ", " & S & ", '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                    Try
                        CONN.Open()
                        If CONN.State = Data.ConnectionState.Open Then
                            REGISTROS = QUERY.ExecuteNonQuery
                        End If
                    Catch ex As Exception
                        MsgBox("Error ocasionado por15 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                    End Try
                    CONN.Close()
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                f_imprimir_envio()
            End If
            If trato.Checked = True Then
                salto = 1
                CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                QUERY = New SqlCeCommand("INSERT INTO TB_DETALLE_ENVIO(ENVIO, DETALLE,FECHA_CORTE, SERIE, TIPO) VALUES  (" & NUMERO_REP & ", " & salto & ", '" + fecha_corte.Text + "', '" + serie_preparada + "', '" + tipot.Text + "');", CONN)
                Try
                    CONN.Open()
                    If CONN.State = Data.ConnectionState.Open Then
                        REGISTROS = QUERY.ExecuteNonQuery
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por16 " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
                End Try
                CONN.Close()
                f_imprimir_envio()
            End If
        End If

        '' RESPUESTA = MsgBox("Desea un nuevo envio?", MsgBoxStyle.YesNo, "Nuevo Envio")
        '' If RESPUESTA = MsgBoxResult.Yes Then
        ''numero_reporte()
        ''Else
        ''IMPRESIONES = IMPRESIONES
        ''End If

        ''txtLatitud.Text = ""
        ''txtLongitud.Text = ""
        '  Catch ex As Exception
        ' MsgBox("Error ocacionado por 18" & ex.Message & vbCrLf & "Favor de Reportarlo.")
        'End Try
    End Sub
    Private Sub Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nuevo.Click
        createxto()
        Me.Filas.Text = ""
        Me.posi.Text = ""
        Me.corta.Text = ""
        Me.racimo.Text = ""
        'Me.detalle.Text = ""
        Me.Generado.Text = ""
        Me.Hide()
        'VENTANA_transporte.Hide()
        'lectura.peri.Text = ""
        'lectura.pilo.Text = ""
        'lectura.trans.Text = ""
        'lectura.vehi.Text = ""
        'lectura.scanner.Text = ""
        'transporte.Id_piloto.Text = ""
        'transporte.Id_ticket.Text = ""
        'transporte.id_transportista.Text = ""
        'transporte.id_vehiculo.Text = ""
        'transporte.Nombre_transportista.Text = ""
        'transporte.Piloto.Text = ""
        'transporte.Placa.Text = ""
        'Me.Hide()
        'Transporte.Close()
        'lectura.Close()
        'Ingreso_finca.Show()
        ' ventana.Show()
        'ventana.empresa = empresa
        'ventana.Show()
        'ventana.tipo = tipo
        'Dim ventana_tipo As New tipo_envio
        'ventana_tipo.empresa = empresa
        'Me.Dispose()
        'Me.Close()
        'ventana_tipo.Show()
    End Sub

    Private Sub login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login.Click
        If usuario.TextLength > 0 Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NOMBREBD)
            Dim QUERY = New SqlCeCommand("SELECT USUARIO, PASSWORD FROM TB_USUARIOS WHERE USUARIO = '" & usuario.Text & "';", CONN)
            'Dim QUERY = New SqlCeCommand("SELECT C.RAZON_SOCIAL FROM TB_CONTRATISTAS A, TB_ENTIDADES_X_EMPRESA B, TB_ENTIDADES C WHERE A.ID_CORRELATIVO_ENTIDAD = B.ID_CORRELATIVO_ENTIDAD AND B.ID_ENTIDAD = C.ID_ENTIDAD AND A.ID_CONTRATISTA = " & Convert.ToInt32(id_contratista.Text.Trim) & ";", CONN)
            Dim dr As SqlCeDataReader = Nothing
            Dim PASSWORD As String = Nothing
            Dim USER As String = Nothing
            Try
                CONN.Open()
                dr = QUERY.ExecuteReader()
                While dr.Read()
                    USER = dr(0).ToString
                    PASSWORD = dr(1).ToString
                End While
                If usuario.Text = USER Then
                    If contraseña.Text = PASSWORD Then
                        VALIDA = 1
                        SUPER = 0
                    Else
                        VALIDA = -1
                    End If
                Else
                    VALIDA = -2
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        End If
        If VALIDA = -1 Then
            MsgBox("Contraseña Erronea")
        ElseIf VALIDA = -2 Then
            Dim valor As Integer
            valor = verifica_supervisor()
            If valor = 5 Then
                MsgBox("Usuario no existe")
            ElseIf valor = 4 Then
                MsgBox("Contraseña Erronea")
            ElseIf valor = 6 Then
                Generar.Visible = False
                VALIDA = 1
                babrir.Visible = False
                bcerrar.Visible = True
                clobservaciones.Visible = True
                lobservacion.Visible = True
                btturno.Visible = True
                SUPER = 1
            End If
        End If
        If VALIDA = 1 Then
            verificar_turno()
            MsgBox("Bienvenido")
            'Dim ventana As New envio
            'ventana.usuario = usuario.Text
            'ventana.Show()
            'leertexto()
            If valida2 <> 4 Then
                If Not gps.Opened Then gps.Open()
                'numero_reporte()
                SERIE_ENVIO()
                'numero_archivo = NUMERO_REP
                'lno.Text = numero_archivo
                'lserie.Text = serie_preparada
                'sr1.Text = serie_preparada
                'nor1.Text = numero_archivo
                coleccion.Visible = True
                coleccion.Controls.Item(0).Visible = True
                'coleccion.Controls.Item(1).Visible = False
                coleccion.Controls.Item(2).Visible = True
                'fecha_reporte.Text = Now.ToString("ddMMyyyy")
            End If
        Else
            MsgBox("Funcion invalida o incorrecta")
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        id_transportista.Text = trans.Text
        id_vehiculo.Text = vehi.Text
        Id_piloto.Text = pilo.Text
        ruta.Text = id_ruta.Text
        If ((Empresa.Text <> "6326") And (Empresa.Text <> "6327")) Then
            If id_ruta.TextLength > 0 Then
                Dim numero As Integer
                Try
                    numero = Convert.ToInt32(id_ruta.Text.Trim)
                    If (((numero > 0) And (numero < 7)) Or ((numero > 9) And (numero < 40))) Then
                        If tipot.Text = "M" Or tipot.Text = "L" Or tipot.Text = "T" Then
                            carga_envio()
                            coleccion.TabPages.Item(5).BringToFront()
                            coleccion.SelectedIndex = 5
                        Else
                            coleccion.TabPages.Item(4).BringToFront()
                            coleccion.SelectedIndex = 4
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    id_ruta.Focus()
                End Try
            End If
        Else
            coleccion.TabPages.Item(4).BringToFront()
            coleccion.SelectedIndex = 4
        End If
        carga_transporte()
    End Sub

    Private Sub carga_envio()
        'leertexto()
        If count_carga_env = 0 Then
            If Empresa.Text = "6327" Then
                SERIE_ENVIO()
            ElseIf Empresa.Text = "6326" Then
                SERIE_ENVIO()
                ' serie_preparada = serie_preparada & tipot.Text
                serie_preparada = serie_preparada & tipotserie
            Else
                'SERIE_ENVIO()
                serie_preparada = serie_preparada & tipotserie
                'serie_preparada = serie_preparada & tipot.Text
            End If
            count_carga_env = count_carga_env + 1
        Else
            serie_preparada = serie_preparada
        End If
        If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
            Filas.Visible = True
            Filas.Enabled = True
            posi.Visible = True
            posi.Enabled = True
            corta.Visible = True
            corta.Enabled = True
            racimo.Visible = True
            racimo.Enabled = True
            Borrar.Visible = True
            Borrar.Enabled = True
            Agregar.Visible = True
            Agregar.Enabled = True
            Label33.Show()
            Label33.Visible = True
            Label32.Visible = True
            Label31.Visible = True
            Label30.Visible = True
            Label30.Text = "Uñadas"
            Button12.Visible = True
            Button11.Visible = True
            'equivalencia.Items.Add("CAGR")
            equivalencia.Items.Add("F101")
            equivalencia.Items.Add("F102")
            equivalencia.Items.Add("F103")
            equivalencia.Items.Add("F104")
            equivalencia.Items.Add("F105")
            equivalencia.Items.Add("F106")
            equivalencia.Items.Add("F107")
            fecha_corte.Visible = True
            Label29.Visible = True
            DateTimePicker5.Visible = True
            lequivalencia.Visible = True
            equivalencia.Visible = True
            trato.Visible = True
            contraid.Visible = True
            lcontratista.Visible = True
        ElseIf tipot.Text = "L" Then
            Filas.Visible = True
            Filas.Enabled = True
            posi.Visible = True
            posi.Enabled = True
            corta.Visible = True
            corta.Enabled = True
            racimo.Visible = True
            racimo.Enabled = True
            Borrar.Visible = True
            Borrar.Enabled = True
            Agregar.Visible = True
            Agregar.Enabled = True
            Label33.Show()
            Label33.Visible = True
            Label32.Visible = True
            Label31.Visible = True
            Label30.Visible = True
            Label30.Text = "Quintales"
            Button12.Visible = True
            Button11.Visible = True
            equivalencia.Items.Add("F201")
            equivalencia.Items.Add("F202")
            equivalencia.Items.Add("F203")
            'equivalencia.Items.Add("CMCC")
            fecha_corte.Visible = True
            Label29.Visible = True
            DateTimePicker5.Visible = True
            lequivalencia.Visible = True
            equivalencia.Visible = True
            trato.Visible = True
            contraid.Visible = True
            lcontratista.Visible = True
        ElseIf tipot.Text = "M" Then
            posi.Visible = True
            posi.Enabled = True
            corta.Visible = True
            corta.Enabled = True
            racimo.Visible = True
            racimo.Enabled = True
            Borrar.Visible = True
            Borrar.Enabled = True
            Agregar.Visible = True
            Agregar.Enabled = True
            Label32.Visible = True
            Label32.Text = "Corta"
            Label31.Visible = True
            Label31.Text = "Trac"
            Label30.Visible = True
            Label30.Text = "Carre"
            op_alz.Visible = True
            op_trac.Visible = True
            Label35.Visible = True
            Label35.Text = "Oper C."
            Label36.Visible = True
            corta.MaxLength = 3
            editar.Visible = False
        ElseIf tipot.Text = "U" Then
            Label31.Visible = True
            Label30.Visible = True
            Label30.Text = "Canastas"
            corta.Visible = True
            corta.Enabled = True
            racimo.Visible = True
            racimo.Enabled = True
            Borrar.Visible = True
            Borrar.Enabled = True
            Agregar.Visible = True
            Agregar.Enabled = True
            Label36.Visible = False
            Label35.Visible = False
            op_alz.Visible = False
            op_trac.Visible = False
            fecha_corte.Visible = False
            equivalencia.Visible = False
            Button12.Visible = True
            Button11.Visible = True
            Button8.Visible = True
            editar.Visible = True
            trato.Visible = False
        ElseIf tipot.Text = "V" Then
            Label31.Visible = True
            Label30.Visible = True
            Label30.Text = "Racimos"
            Label32.Text = "Sacos"
            Label32.Visible = True
            posi.Visible = True
            corta.Visible = True
            corta.Enabled = True
            racimo.Visible = True
            racimo.Enabled = True
            Borrar.Visible = True
            Borrar.Enabled = True
            Agregar.Visible = True
            Agregar.Enabled = True
            Label36.Visible = False
            Label35.Visible = False
            op_alz.Visible = False
            op_trac.Visible = False
            fecha_corte.Visible = False
            equivalencia.Visible = False
            Button12.Visible = True
            Button11.Visible = True
            Button9.Visible = True
            editar.Visible = True
            trato.Visible = False
        ElseIf tipot.Text = "T" Then
            posi.MaxLength = 5
            posi.Visible = True
            posi.Enabled = True
            Borrar.Visible = True
            Borrar.Enabled = True
            Agregar.Visible = True
            Agregar.Enabled = True
            Label32.Visible = True
            Label32.Text = "Corta"
            lequivalencia.Visible = True
            fecha_corte.Visible = True
            Label9.Visible = True
            Label29.Visible = True
            Label24.Visible = True
            DateTimePicker5.Visible = True
            equivalencia.Visible = True
            id_contratista.Visible = True
            posi.Size = New System.Drawing.Size(97, 32)
            'equivalencia.Items.Add("FR01")
            'equivalencia.Items.Add("GY01")
            'equivalencia.Items.Add("GY02")
            'equivalencia.Items.Add("GY03")
            'equivalencia.Items.Add("IN01")
            'equivalencia.Items.Add("RV01")
            'equivalencia.Items.Add("JH01")
            'equivalencia.Items.Add("CTFR")
            equivalencia.Items.Add("F302")
            equivalencia.Items.Add("F303")
            equivalencia.Items.Add("F304")
            trato.Visible = True
        End If
        Tipo_boleta.Text = tipot.Text
        CONTADOR = -1
        total_bruto = 0
        total_neto = 0
        total_tara = 0
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        carga_envio()
        coleccion.TabPages.Item(5).BringToFront()
        coleccion.SelectedIndex = 5
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim valida_unidad As Integer = 0
        Dim unidad_new As Integer = 0
        'If (unidad.Text = "") Then
        'xunidad.Text = "1"
        'End If
        'unidad_new = Convert.ToInt32(unidad.Text)
        If (tipot.Text = "T" And unidad.Text = "") Then
            MsgBox("Cantidad Maletas <<Obligatorio>> ")
            unidad.Focus()
        ElseIf (tipot.Text = "T" And unidad.Text = 0) Then
            MsgBox("Cantidad Maletas <<Cero 0 no valido>>")
            unidad.Focus()
        ElseIf (tipot.Text = "T" And unidad.Text >= 6) Then
            MsgBox("<<Exede cantidad de maletas>>")
            unidad.Focus()
        ElseIf (tipot.Text = "L" And unidad.Text = "") Then
            MsgBox("Cantidad Maletas <<Obligatorio>>")
            unidad.Focus()
        ElseIf (tipot.Text = "L" And unidad.Text = 0) Then
            MsgBox("Cantidad Maletas <<Cero 0 no valido>>")
            unidad.Focus()
        ElseIf (tipot.Text = "L" And unidad.Text >= 75) Then
            MsgBox("<<Exede numero permitido>>")
            unidad.Focus()
        Else
            valida_unidad = 1
        End If

        '9900
        If tipot.Text = "T" Then
            plata.Visible = False
            cole.Visible = False
            Nboleta.Visible = False
            Label39.Visible = False
            Label25.Visible = False
            Label26.Visible = False

            Nboleta.Text = "0"
            plata.Text = "0"
            cole.Text = "0"
        Else
            plata.Visible = True
            cole.Visible = True
            Nboleta.Visible = True
            Label39.Visible = True
            Label25.Visible = True
            Label26.Visible = True
        End If


        If (valida_unidad = 1) Then
            If txtLote.Text.Length <= 0 Then
                MsgBox("Ingrese pante valido")
            Else
                carga_lectura()
                coleccion.TabPages.Item(3).BringToFront()
                coleccion.SelectedIndex = 3
            End If
        Else
            unidad.Focus()
        End If
    End Sub

    Private Sub Salida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salida.Click
        If gps.Opened Then gps.Close()
        p_placa = ""
        Application.Exit()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub DateTimePicker5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker5.ValueChanged
        fecha_corte.Text = DateTimePicker5.Text.Substring(0, 8)
    End Sub

    Private Sub lipa5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lipa5.LostFocus
        lilo5.Items.Clear()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        Try
            If (Id_finca.Text.Length > 0) And (lipa5.Items.Item(lipa5.SelectedIndex).ToString.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim npante As Integer = Nothing
                Try
                    valor = Convert.ToInt32(Id_finca.Text)
                    npante = Convert.ToInt32(lipa5.Items.Item(lipa5.SelectedIndex))
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        nfinca = 0
                        npante = 0
                    Else
                        If tipot.Text <> "U" Then
                            npante = Convert.ToInt32(lipa5.Items.Item(lipa5.SelectedIndex))
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & Id_finca.Text & ") AND (ID_PANTE = " & Convert.ToInt32(lipa5.Items.Item(lipa5.SelectedIndex)) & " and estado = 'ACT' );", CONN)
                            If Empresa.Text.Trim = "1" Then
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            Else
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT');", CONN)
                            End If
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo5.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo5.Items.Add(0)
                            End If
                        ElseIf tipot.Text = "U" Then
                            npante = 1
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim nlote = Convert.ToInt32(lipa5.Items.Item(lipa5.SelectedIndex))
                            Dim QUERYl = New SqlCeCommand("SELECT id_variedad FROM TB_LOTES WHERE (ID_FINCA = " & Id_finca.Text & ") AND (ID_PANTE = " & 1 & "  and id_lote = " & Convert.ToInt32(lipa5.Items.Item(lipa5.SelectedIndex)) & " and estado = 'ACT' );", CONN)
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo5.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo5.Items.Add(0)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    'lipante.Focus()
                    'id_finca.Text = "0"
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub lipa6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lipa6.LostFocus
        lilo6.Items.Clear()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        Try
            If (Id_finca.Text.Length > 0) And (lipa6.Items.Item(lipa6.SelectedIndex).ToString.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim npante As Integer = Nothing
                Try
                    valor = Convert.ToInt32(Id_finca.Text)
                    npante = Convert.ToInt32(lipa6.Items.Item(lipa6.SelectedIndex))
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        nfinca = 0
                        npante = 0
                    Else
                        If tipot.Text <> "U" Then
                            npante = Convert.ToInt32(lipa6.Items.Item(lipa6.SelectedIndex))
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & Id_finca.Text & ") AND (ID_PANTE = " & Convert.ToInt32(lipa6.Items.Item(lipa6.SelectedIndex)) & " and estado = 'ACT' );", CONN)
                            If Empresa.Text.Trim = "1" Then
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT' AND ID_CULTIVO = 1);", CONN)
                            Else
                                QUERYl = New SqlCeCommand("SELECT ID_LOTE FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & ") AND (ID_PANTE = " & npante & " and estado = 'ACT');", CONN)
                            End If
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo6.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo6.Items.Add(0)
                            End If
                        ElseIf tipot.Text = "U" Then
                            npante = 1
                            nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                            Dim nlote = Convert.ToInt32(lipa6.Items.Item(lipa6.SelectedIndex))
                            Dim QUERYl = New SqlCeCommand("SELECT id_variedad FROM TB_LOTES WHERE (ID_FINCA = " & Id_finca.Text & ") AND (ID_PANTE = " & 1 & "  and id_lote = " & Convert.ToInt32(lipa6.Items.Item(lipa6.SelectedIndex)) & " and estado = 'ACT' );", CONN)
                            Dim lotes As Integer = 0
                            CONN.Open()
                            drl = QUERYl.ExecuteReader()
                            While drl.Read()
                                lilo6.Items.Add(drl(0).ToString.Trim)
                                lotes = lotes + 1
                            End While
                            If lotes = 0 Then
                                lilo6.Items.Add(0)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    'lipante.Focus()
                    'id_finca.Text = "0"
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub DateTimePicker6_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker6.ValueChanged
        quema5.Text = DateTimePicker6.Text.Substring(0, 8)
        hora5.Text = DateTimePicker6.Text.Substring(8, 4)
    End Sub

    Private Sub DateTimePicker7_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker7.ValueChanged
        quema6.Text = DateTimePicker7.Text.Substring(0, 8)
        hora6.Text = DateTimePicker7.Text.Substring(8, 4)
    End Sub
    'METODOS AGREGADOS Y EVENTOS REQUERIDOS POR LIBRERIA GPS
    'Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    updateDataHandler = New EventHandler(AddressOf UpdateData)
    '    AddHandler gps.DeviceStateChanged, New DeviceStateChangedEventHandler(AddressOf gps_DeviceStateChanged)
    '    AddHandler gps.LocationChanged, New LocationChangedEventHandler(AddressOf gps_LocationChanged)
    'End Sub
    Protected Sub gps_LocationChanged(ByVal sender As Object, ByVal args As LocationChangedEventArgs)
        position = args.Position
        Invoke(updateDataHandler)
    End Sub

    Protected Sub gps_DeviceStateChanged(ByVal sender As Object, ByVal args As DeviceStateChangedEventArgs)
        device = args.DeviceState
        Invoke(updateDataHandler)
    End Sub


    Private Sub UpdateData()
        If gps.Opened Then
            If Not position Is Nothing Then
                If position.LatitudValida Then
                    txtLatitud.Text = position.LatitudEnGradosMinutosSegundos.ToString
                End If
                If position.LongitudValida Then
                    txtLongitud.Text = position.LongitudEnGradosMinutosSegundos.ToString
                End If
            End If
        End If

    End Sub
    Private Sub ocorte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ocorte.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(ocorte.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                'ocorte.Focus()
            Else
                Croquis.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            'ocorte.Focus()
            ocorte.Text = "0"
        End Try
    End Sub

    Private Sub Croquis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Croquis.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(Croquis.Text)
            If Croquis.TextLength < 0 Then
                'If valor < 0 Then
                MsgBox("ingrese numeros")
                Croquis.Focus()
            Else
                siguiente.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            'Croquis.Focus()
            Croquis.Text = "0"
        End Try
    End Sub

    Private Sub plata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles plata.LostFocus
        '' ''Dim valor As Integer = Nothing
        '' ''Try
        '' ''    valor = Convert.ToInt32(plata.Text)
        '' ''    If valor < 0 Then
        '' ''        MsgBox("ingrese numeros")
        '' ''        plata.Focus()
        '' ''    End If
        '' ''Catch ex As Exception
        '' ''    MsgBox("Ingrese numeros")
        '' ''    plata.Focus()
        '' ''    plata.Text = "0"
        '' ''End Try
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim drp As SqlCeDataReader = Nothing
        Dim nplata As Integer
        Dim mingo As Object = Convert.DBNull
        If plata.Text.Length > 0 And tipot.Text <> "T" Then
            Try
                Dim valor As Integer = Nothing
                valor = Convert.ToInt32(plata.Text)
                If valor < 0 Then
                    'MsgBox("ingrese numeros")
                    plata.Text = 0
                Else
                    nplata = Convert.ToInt32(plata.Text.Trim)
                    If tipot.Text <> "U" Then
                        Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA = 17 AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & nplata & ";", CONN)
                        Dim PLATAFORMA As Integer = 0
                        CONN.Open()
                        drp = QUERYp.ExecuteReader()
                        While drp.Read()
                            If (drp(0).Equals(mingo)) Then
                                PLATAFORMA = 0
                            Else
                                PLATAFORMA = Convert.ToInt32(drp(0).ToString.Trim)
                            End If
                        End While
                        If PLATAFORMA = 0 Then
                            MsgBox("Plataforma no valida")
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                plata.Focus()
                plata.Text = "800"
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
        End If
        CONN.Close()
    End Sub

    Private Sub cole_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cole.LostFocus
        '' ''Dim valor As Integer = Nothing
        '' ''Try
        '' ''    valor = Convert.ToInt32(cole.Text)
        '' ''    If valor < 0 Then
        '' ''        MsgBox("ingrese numeros")
        '' ''        cole.Focus()
        '' ''    End If
        '' ''Catch ex As Exception
        '' ''    MsgBox("Ingrese numeros")
        '' ''    cole.Focus()
        '' ''    cole.Text = "0"
        '' ''End Try
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim drp As SqlCeDataReader = Nothing
        Dim nCOLE As Integer
        Dim mingo As Object = Convert.DBNull
        If cole.Text.Length > 0 Then
            Try
                Dim valor As Integer = Nothing
                valor = Convert.ToInt32(cole.Text)
                If valor < 0 Then
                    'MsgBox("ingrese numeros")
                    cole.Text = 0
                Else
                    nCOLE = Convert.ToInt32(cole.Text.Trim)
                    If tipot.Text <> "U" Then
                        Dim QUERYp = New SqlCeCommand("SELECT ID_MAQUINARIA FROM TB_MAQUINARIA WHERE ID_TIPO_MAQUINARIA = 45 AND ESTADO = 'ACT' AND ID_MAQUINARIA = " & nCOLE & ";", CONN)
                        Dim COLERA As Integer = 0
                        CONN.Open()
                        drp = QUERYp.ExecuteReader()
                        While drp.Read()
                            If (drp(0).Equals(mingo)) Then
                                COLERA = 0
                            Else
                                COLERA = Convert.ToInt32(drp(0).ToString.Trim)
                            End If
                        End While
                        If COLERA = 0 Then
                            MsgBox("Colera no valida")
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                cole.Focus()
                cole.Text = "0"
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
        End If
        CONN.Close()
    End Sub

    Private Sub cortadores_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cortadores.TextChanged
        Dim cantidad As Integer = Nothing
        cantidad = Convert.ToInt32(cortadores.Text)
        If cantidad > 0 Then
            Button9.Visible = True
            Button8.Visible = True
            ncorta.Visible = True
            cantidad = cantidad
        Else
            Button9.Visible = False
            Button8.Visible = False
            ncorta.Visible = False
        End If
    End Sub

    Private Sub siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles siguiente.Click
        If tipotserie.Length > 0 And tipot.Text.Length > 0 Then
            If ocorte.Text = "" Or ocorte.Text <= 0 Then
                MsgBox("Ingresar Orden de Corte Valida")
            Else
                carga_ingreso_finca()
                If tipot.Text = "M" Or tipot.Text = "L" Or tipot.Text = "T" Then
                    coleccion.TabPages.Item(4).Hide()
                End If
                coleccion.TabPages.Item(2).BringToFront()
                coleccion.SelectedIndex = 2
            End If
        Else
            MsgBox("No ha elegido ningun tipo de caña")
        End If
    End Sub

    Private Sub editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editar.Click
        navegar = 0
        Dim EDITADO As String = Nothing
        Dim nuevo_detalle As String = Nothing
        Dim salto As Integer = 0
        Dim comparaa As String = ""
        Dim comparab As String = ""
        Dim contadore As Integer = 0
        Dim coincidencia As Integer = 0
        If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "L" Then
            If Filas.Text <> "" And posi.Text <> "" And corta.Text <> "" And racimo.Text <> "" And fecha_corte.Text <> "" And equivalencia.Text <> "" Then
                If detallet.TextLength > 0 Then
                    salto = Convert.ToInt32(detallet.TextLength / 35)
                    While contadore < salto
                        comparab = detallet.Text.Substring(contadore * 35, 6)
                        comparaa = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) '+ Lpad(corta.Text, "0", 6) '+ Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                        contadore = contadore + 1
                        If comparaa = comparab And contadore <> ncorta.Text Then
                            coincidencia = coincidencia + 1
                        End If

                    End While
                    If coincidencia = 0 Then
                        EDITADO = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                        'detalle.Text = detalle.Text + Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper
                    ElseIf coincidencia > 0 Then
                        MsgBox("los datos que quiere ingresar ya existen en este envio verifique")
                    End If
                Else
                    detallet.Text = Lpad(Filas.Text, "0", 3) + Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3) + Lpad(fecha_corte.Text, "0", 8) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(contraid.Text, "0", 6).ToUpper
                End If
                If coincidencia = 0 Then
                    Filas.Text = ""
                    posi.Text = ""
                    corta.Text = ""
                    racimo.Text = ""
                    contraid.Text = ""
                    ' agrego = 1
                End If
                'fecha_corte.Text = ""
                'Equivalencia.Text = ""
            Else
                MsgBox("Los campos fila, posicion, cortador, uñadas, fecha de corte y equivalencia no deben quedar vacios ")
            End If
            'Filas.Text = ""
            'posi.Text = ""
            'corta.Text = ""
            'racimo.Text = ""
        ElseIf TIPO = "M" Then
            EDITADO = Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 3) + Lpad(racimo.Text, "0", 3) + Lpad(op_alz.Text, "0", 6) + Lpad(op_trac.Text, "0", 6)
            posi.Text = ""
            corta.Text = ""
            racimo.Text = ""
            op_alz.Text = ""
            op_trac.Text = ""
        ElseIf TIPO = "T" Then
            EDITADO = Lpad(posi.Text, "0", 6) + Lpad(equivalencia.Text, "0", 6).ToUpper + Lpad(fecha_corte.Text, "0", 8)
            posi.Text = ""
            equivalencia.Text = ""
        ElseIf TIPO = "U" Then
            EDITADO = Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3)
            corta.Text = ""
            racimo.Text = ""
        ElseIf TIPO = "V" Then
            EDITADO = Lpad(posi.Text, "0", 3) + Lpad(corta.Text, "0", 6) + Lpad(racimo.Text, "0", 3)
            posi.Text = ""
            corta.Text = ""
            racimo.Text = ""
        End If
        If registro = 1 Then
            nuevo_detalle = detallet.Text.Substring(largo, detallet.Text.Length - largo)
            detallet.Text = EDITADO + nuevo_detalle
        ElseIf registro = acumulador Then
            nuevo_detalle = detallet.Text.Substring(0, detallet.Text.Length - largo)
            detallet.Text = nuevo_detalle + EDITADO
        Else
            nuevo_detalle = detallet.Text.Substring(0, ((registro - 1) * largo)) + EDITADO + detallet.Text.Substring((registro * largo), (detallet.Text.Length - (largo * registro)))
            detallet.Text = nuevo_detalle
        End If
        If navegar = 0 Then
            Agregar.Visible = True
        End If
        contadore = 0
    End Sub

    Private Sub id_contratista_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles id_contratista.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(id_contratista.Text)
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
            Dim QUERY = New SqlCeCommand("SELECT C.RAZON_SOCIAL FROM TB_CONTRATISTAS A, TB_ENTIDADES_X_EMPRESA B, TB_ENTIDADES C WHERE A.ID_CORRELATIVO_ENTIDAD = B.ID_CORRELATIVO_ENTIDAD AND B.ID_ENTIDAD = C.ID_ENTIDAD AND A.ID_CONTRATISTA = " & Convert.ToInt32(id_contratista.Text.Trim) & ";", CONN)
            Dim dr As SqlCeDataReader = Nothing
            Try
                If id_contratista.Text.Length > 0 Then
                    CONN.Open()
                    dr = QUERY.ExecuteReader()
                    While dr.Read()
                        Contratista.Text = dr(0).ToString
                        If Contratista.Text = "" Then
                            Contratista.Text = "----"
                        End If
                    End While
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
            If valor < 0 Then
                MsgBox("ingrese numeros")
                id_contratista.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            id_contratista.Focus()
            id_contratista.Text = "0"
        End Try
    End Sub

    '' ''Private Sub ENTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRAR.Click
    '' ''    If ussuper.TextLength > 0 Then
    '' ''        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NOMBREBD)
    '' ''        Dim QUERY = New SqlCeCommand("SELECT USUARIO, PASSWORD FROM TB_USUARIOS WHERE USUARIO = '" & ussuper.Text & "';", CONN)
    '' ''        Dim dr As SqlCeDataReader = Nothing
    '' ''        Dim PASSWORD As String = Nothing
    '' ''        Dim USER As String = Nothing
    '' ''        Try
    '' ''            CONN.Open()
    '' ''            dr = QUERY.ExecuteReader()
    '' ''            While dr.Read()
    '' ''                USER = dr(0).ToString
    '' ''                PASSWORD = dr(1).ToString
    '' ''            End While
    '' ''            If ussuper.Text = USER Then
    '' ''                If passuper.Text = PASSWORD Then
    '' ''                    VALIDA = 1
    '' ''                Else
    '' ''                    VALIDA = -1
    '' ''                End If
    '' ''            Else
    '' ''                VALIDA = -2
    '' ''            End If
    '' ''        Catch ex As Exception
    '' ''            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
    '' ''                        "Favor de reportarlo.")
    '' ''        End Try
    '' ''        CONN.Close()
    '' ''    End If
    '' ''    If VALIDA = -1 Then
    '' ''        MsgBox("Contraseña Erronea")
    '' ''    ElseIf VALIDA = -2 Then
    '' ''        MsgBox("Usuario no existe")
    '' ''    ElseIf VALIDA = 1 Then
    '' ''        lbuscar.Visible = True
    '' ''        Buscar.Visible = True
    '' ''        Reporte.Visible = True
    '' ''        lserie.Visible = True
    '' ''        serie_env.Visible = True
    '' ''    Else
    '' ''        MsgBox("Funcion invalida o incorrecta")
    '' ''    End If
    '' ''End Sub
    Private Function verifica_supervisor() As Integer
        Dim resultado As Integer
        resultado = 0
        If usuario.TextLength > 0 Then
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            Dim QUERY = New SqlCeCommand("SELECT USUARIO, PASSWORD FROM TB_USUARIOS WHERE USUARIO = '" & usuario.Text & "';", CONN)
            Dim dr As SqlCeDataReader = Nothing
            Dim PASSWORD As String = Nothing
            Dim USER As String = Nothing
            Try
                CONN.Open()
                dr = QUERY.ExecuteReader()
                While dr.Read()
                    USER = dr(0).ToString
                    PASSWORD = dr(1).ToString
                End While
                If usuario.Text = USER Then
                    If contraseña.Text = PASSWORD Then
                        VALIDA = 1
                    Else
                        VALIDA = -1
                    End If
                Else
                    VALIDA = -2
                End If
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        End If
        If VALIDA = -1 Then
            resultado = 4
            'MsgBox("Contraseña Erronea")
        ElseIf VALIDA = -2 Then
            resultado = 5
            'MsgBox("Usuario no existe")
        ElseIf VALIDA = 1 Then
            resultado = 6
            lbuscar.Visible = True
            Buscar.Visible = True
            Reporte.Visible = True
            lserie.Visible = True
            serie_env.Visible = True
            'Else
            'MsgBox("Funcion invalida o incorrecta")
        End If
        Return resultado
    End Function
    Private Sub Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buscar.Click
        Dim valida As Integer = 0
        If serie_env.Text <> "" Then
            If Reporte.Text <> "" Then
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                Dim QUERY = New SqlCeCommand("select * from TB_ENVIOS where serie = '" + serie_env.Text.ToUpper + "' and envio =" & Convert.ToInt32(Reporte.Text) & " ;", CONN)
                Dim dr As SqlCeDataReader = Nothing
                Try
                    CONN.Open()
                    dr = QUERY.ExecuteReader
                    While dr.Read()
                        valida = valida + 1
                    End While
                    If valida >= 1 Then
                        Reimprimir.Visible = True
                    Else
                        Reimprimir.Visible = False
                        MsgBox("envio no existe")
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                               "Favor de reportarlo.")
                End Try
            Else
                MsgBox("El numero de envio no puede estar vacio")
            End If
        Else
            MsgBox("La Serie del envio no puede estar vacia")
        End If
    End Sub

    Private Sub Reimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reimprimir.Click
        Dim vr_RESPUESTA As MsgBoxResult = Nothing
        Dim vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim vr_QUERY = New SqlCeCommand("select * from TB_ENVIOS where envio =" & Convert.ToInt32(Reporte.Text) & " AND serie = '" + serie_env.Text.ToUpper + "';", vr_CONN)
        Dim vr_dr As SqlCeDataReader = Nothing
        Dim vr_dr2 As SqlCeDataReader = Nothing
        Dim vr_fecha1 As DateTime = Nothing
        Dim vr_fecha2 As DateTime = Nothing
        Dim vr_fecha3 As DateTime = Nothing
        Dim vr_fecha4 As DateTime = Nothing
        Dim vr_fecha5 As DateTime = Nothing
        Dim vr_fecha6 As DateTime = Nothing
        Dim vr_croquis As Integer = 0
        Dim vr_ocorte As Integer = 0
        Dim vr_fecha_turno As DateTime = Nothing
        Dim vr_latitud As String = Nothing
        Dim vr_longitud As String = Nothing
        Dim vr_presenta As String = Nothing
        Dim vr_estadof As String = Nothing
        Try
            If vr_CONN.State <> Data.ConnectionState.Open Then
                vr_CONN.Open()
            Else
                vr_CONN.Close()
                vr_CONN.Open()
            End If
            vr_dr = vr_QUERY.ExecuteReader
            While vr_dr.Read()
                vr_serie_preparada = vr_dr(0).ToString
                vr_numero_archivo = Convert.ToString(vr_dr(1))
                vr_fecha1 = vr_dr(2)
                vr_finca = vr_dr(3).ToString
                vr_frente = vr_dr(4).ToString
                vr_pante1 = vr_dr(5).ToString
                vr_pante2 = vr_dr(6).ToString
                vr_pante3 = vr_dr(7).ToString
                vr_pante4 = vr_dr(8).ToString
                vr_lote1 = vr_dr(9).ToString
                vr_lote2 = vr_dr(10).ToString
                vr_lote3 = vr_dr(11).ToString
                vr_lote4 = vr_dr(12).ToString
                If vr_dr(13).Equals(Nothing) Then
                    vr_fecha2 = Nothing
                Else
                    vr_fecha2 = vr_dr(13)
                End If
                If vr_dr(14).Equals(mingo) Then
                    vr_fecha3 = Nothing
                Else
                    vr_fecha3 = vr_dr(14)
                End If
                If vr_dr(15).Equals(mingo) Then
                    vr_fecha4 = Nothing
                Else
                    vr_fecha4 = vr_dr(15)
                End If
                If vr_dr(16).Equals(mingo) Then
                    vr_fecha5 = Nothing
                Else
                    vr_fecha5 = vr_dr(16)
                End If
                If vr_dr(41).Equals(mingo) Then
                    vr_fecha_turno = Nothing
                Else
                    vr_fecha_turno = vr_dr(41)
                End If
                vr_ruta = vr_dr(17).ToString
                vr_zona = vr_dr(18).ToString
                vr_grupo = vr_dr(19).ToString
                vr_trans = vr_dr(20).ToString
                vr_vehi = vr_dr(21).ToString
                vr_pilo = vr_dr(22).ToString
                vr_empresa = vr_dr(23).ToString
                vr_peri = vr_dr(24).ToString
                vr_enviero = vr_dr(25).ToString
                vr_contratista = vr_dr(26).ToString
                vr_plata = vr_dr(27).ToString
                vr_cole = vr_dr(28).ToString
                vr_unidad1 = vr_dr(29).ToString
                vr_unidad2 = vr_dr(30).ToString
                vr_unidad3 = vr_dr(31).ToString
                vr_unidad4 = vr_dr(32).ToString
                vr_tipo = vr_dr(33).ToString
                vr_impresiones = Convert.ToInt32(vr_dr(34))
                If vr_dr(35).Equals(mingo) Then
                    vr_fecha6 = Nothing
                Else
                    vr_fecha6 = vr_dr(35)
                End If
                vr_alzador = vr_dr(36).ToString
                vr_tractor = vr_dr(37).ToString
                vr_opera_alz = vr_dr(38).ToString
                vr_opera_tra = vr_dr(39).ToString
                vr_ticket = vr_dr(40).ToString
                vr_presenta = vr_dr(42).ToString
                If vr_dr(43).Equals(mingo) Then
                    vr_latitud = Nothing
                Else
                    vr_latitud = Replace(vr_dr(43).ToString, "|", Chr(39))
                End If
                If vr_dr(44).Equals(mingo) Then
                    vr_longitud = Nothing
                Else
                    vr_longitud = Replace(vr_dr(44).ToString, "|", Chr(39))
                End If
                If vr_dr(45).Equals(mingo) Then
                    vr_estadof = Nothing
                Else
                    vr_estadof = vr_dr(45).ToString
                End If
                If vr_dr(46).Equals(mingo) Then
                    vr_croquis = Nothing
                Else
                    vr_croquis = vr_dr(46).ToString
                End If
                If vr_dr(47).Equals(mingo) Then
                    vr_ocorte = Nothing
                Else
                    vr_ocorte = vr_dr(47).ToString
                End If

            End While
            vr_dr.Close()
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                               "Favor de reportarlo.")
        End Try
        If vr_CONN.State <> Data.ConnectionState.Closed Then
            vr_CONN.Close()
        End If
        Dim vr_conn2 = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim vr_QUERY2 = New SqlCeCommand("select nombre from tb_fincas where id_finca = " & Convert.ToInt32(vr_finca) & ";", vr_conn2)
        Try
            vr_conn2.Open()
            vr_dr2 = vr_QUERY2.ExecuteReader
            While vr_dr2.Read
                vr_nombre_finca = vr_dr2(0)
            End While
            vr_dr2.Close()
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                               "Favor de reportarlo.")
        End Try
        vr_conn2.Close()
        If BTPRINT.IsOpen Then
            BTPRINT.Close()
        End If
        Try
            BTPRINT.Open()
            BTPRINT.WriteTimeout = 20000
            vr_coordenada = 10
            vr_nombre_empresa = ""
            vr_NOMBRE_BOLETA = ""
            vr_UNIDADES = ""
            vr_ENC = ""
            If vr_empresa = "1" Then
                vr_nombre_empresa = "Ingenio El Pilar, S. A."
            Else
                If vr_empresa = "6327" Then
                    vr_nombre_empresa = "PALMA SUR, S. A."
                End If
            End If
            If vr_tipo = "C" Then
                vr_NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL (COLERA)"
                vr_UNIDADES = "UNADAS"
            ElseIf vr_tipo = "G" Then
                vr_NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL"
                vr_UNIDADES = "UNADAS"
            ElseIf vr_tipo = "M" Then
                vr_NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA COSECHA MECANIZADA"
                vr_UNIDADES = "CARRETAS"
            ElseIf vr_tipo = "L" Then
                vr_NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA MALETEADA"
                vr_UNIDADES = "MALETAS"
            ElseIf vr_tipo = "T" Then
                vr_NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA TRAMEADO"
                vr_UNIDADES = "MALETAS"
            ElseIf vr_tipo = "U" Then
                vr_NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A FABRICA"
                vr_UNIDADES = "CANASTAS"
            End If
            vr_ENC = Chr(27) & "EZ" & "{PRINT:" & "@" & vr_coordenada & ",250:MF107,VMULT2|" & vr_nombre_empresa & "|"
            vr_coordenada = vr_coordenada + 70
            vr_ENC &= "@" & vr_coordenada & ", 50:MF107, VMULT2|" & vr_NOMBRE_BOLETA & "|"
            If vr_empresa = "6327" Then
                vr_coordenada = vr_coordenada + 70
                vr_ENC &= "@" & vr_coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & vr_serie_preparada & "|"
            Else
                vr_coordenada = vr_coordenada + 70
                vr_ENC &= "@" & vr_coordenada & ", 50:MF107, VMULT2|" & "                     SERIE: " & vr_serie_preparada & "|"
            End If
            'coordenada = coordenada + 70
            vr_ENC &= "@" & vr_coordenada & ", 50:MF107, VMULT2|ENVIO NO.:   " & Lpad(vr_numero_archivo.ToString, "0", 6) & "|"
            vr_ENC &= "}" & "{AHEAD:12}" & "{LP}"
            BTPRINT.Write(vr_ENC)
            vr_coordenada = 10
            vr_IMP = Chr(27) & "EZ" & "{PRINT:" & "@" & vr_coordenada & ",50:MF204,VMULT1 |FECHA:       " & vr_fecha1.ToString("dd/MM/yyyy HH:mm") & "|" 'Now.ToString("dd/MM/yyyy HH:mm")
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1 |FINCA:       " & Lpad(vr_finca, "0", 3) & "  " & vr_nombre_finca & "|"
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |CROQUIS:                 " & Lpad(vr_croquis, "0", 8) & "|"
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |ORDEN CORTE:             " & Lpad(vr_ocorte, "0", 8) & "|"
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(vr_trans, "0", 4) & "|" '"  " & nombre_trans & 
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(vr_pilo, "0", 3) & "|" '"  " & nombre_pilo &
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vr_vehi, "0", 3) & "|" '"  " & placa_vehi & 
            If (vr_tipo <> "U") Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1 |FRENTE:                  " & Lpad(vr_frente, "0", 3) & "|"
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |BOLETA DE TRANSPORTE:    " & Lpad(vr_ticket, "0", 6) & "|"
            Else
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1 |SECTOR:      " & Lpad(vr_frente, "0", 3) & "|"
            End If
            If vr_tipo <> "U" Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |RUTA:                    " & Lpad(vr_ruta, "0", 3) & "|"
            End If
            If (vr_tipo <> "T") Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |PLATAFORMA:              " & Lpad(vr_plata, "0", 4) & "|"
            End If
            If ((vr_tipo = "C") Or (vr_tipo = "G") Or (vr_tipo = "M")) Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |COLERA:                  " & Lpad(vr_cole, "0", 4) & "|"
            End If
            If (vr_tipo <> "M") Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(vr_contratista, "0", 4) & "|" ' "  " & nombre_contra &
            End If
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |HORA DE DESPACHO:        " & vr_fecha6.ToString("HH:mm") & "|"
            'If (tipo <> "U") Then
            vr_coordenada = vr_coordenada + 30
            If (vr_tipo <> "U") And (vr_tipo <> "T") Then
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |TURNO:                   " & vr_grupo & "|"
            ElseIf vr_tipo = "T" Then
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |CUADRILLA:               " & vr_grupo & "|"
            Else
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |GRUPO:                   " & vr_grupo & "|"
            End If
            If ((vr_tipo = "C") Or (vr_tipo = "G")) Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |ALZADOR:                 " & Lpad(vr_alzador, "0", 3) & "     OPERADOR ALZADOR " & Lpad(vr_opera_alz, "0", 6) & "|"
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |TRACTOR:                 " & Lpad(vr_tractor, "0", 3) & "     OPERADOR TRACTOR " & Lpad(vr_opera_tra, "0", 6) & "|"
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |FECHA TURNO:                 " + vr_fecha_turno.ToString("dd/MM/yyyy") + "|"
            End If
            vr_coordenada = vr_coordenada + 30
            vr_total_unidades = 0
            If vr_unidad1 = "" Then
                vr_total_unidades = vr_total_unidades + 0
            Else
                vr_total_unidades = vr_total_unidades + Convert.ToInt32(vr_unidad1)
            End If
            If vr_unidad2 = "" Then
                vr_total_unidades = vr_total_unidades + 0
            Else
                vr_total_unidades = vr_total_unidades + Convert.ToInt32(vr_unidad2)
            End If
            If vr_unidad3 = "" Then
                vr_total_unidades = vr_total_unidades + 0
            Else
                vr_total_unidades = vr_total_unidades + Convert.ToInt32(vr_unidad3)
            End If
            If vr_unidad4 = "" Then
                vr_total_unidades = vr_total_unidades + 0
            Else
                vr_total_unidades = vr_total_unidades + Convert.ToInt32(vr_unidad4)
            End If
            vr_coordenada = vr_coordenada + 50
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |  PRESENTACION  :        " + vr_presenta + "|"
            If (vr_tipo <> "U") Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |      LOTE          FECH QUEMA      HORA QUEMA      " & vr_UNIDADES & "|"
            Else
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |BLOQUE    VARIEDAD  FECH CORTE      HORA CORTE      " & vr_UNIDADES & "|"
            End If
            vr_fechaq1 = Lpad(vr_fechaq1, "0", 8)
            vr_fechaq2 = Lpad(vr_fechaq2, "0", 8)
            vr_fechaq3 = Lpad(vr_fechaq3, "0", 8)
            vr_fechaq4 = Lpad(vr_fechaq4, "0", 8)
            vr_horaq1 = Lpad(vr_horaq1, "0", 4)
            vr_horaq2 = Lpad(vr_horaq2, "0", 4)
            vr_horaq3 = Lpad(vr_horaq3, "0", 4)
            vr_horaq4 = Lpad(vr_horaq4, "0", 4)
            If (vr_tipo <> "U") Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante1, "0", 3) & "        " & Lpad(vr_lote1, "0", 3) & "        " & vr_fecha2.ToString("dd/MM/yyyy") & "        " & vr_fecha2.ToString("HH:mm") & "         " & Lpad(vr_unidad1, "0", 3) & "|" 'fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4)
                If Convert.ToInt32(vr_lote2) > 0 Then
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante2, "0", 3) & "        " & Lpad(vr_lote2, "0", 3) & "        " & vr_fecha3.ToString("dd/MM/yyyy") & "        " & vr_fecha3.ToString("HH:mm") & "         " & Lpad(vr_unidad2, "0", 3) & "|"
                End If
                If Convert.ToInt32(vr_lote3) > 0 Then
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante3, "0", 3) & "        " & Lpad(vr_lote3, "0", 3) & "        " & vr_fecha4.ToString("dd/MM/yyyy") & "        " & vr_fecha4.ToString("HH:mm") & "         " & Lpad(vr_unidad3, "0", 3) & "|"
                End If
                If Convert.ToInt32(vr_lote4) > 0 Then
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante4, "0", 3) & "        " & Lpad(vr_lote4, "0", 3) & "        " & vr_fecha5.ToString("dd/MM/yyyy") & "        " & vr_fecha5.ToString("HH:mm") & "         " & Lpad(vr_unidad4, "0", 3) & "|"
                End If
            Else
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante1, "0", 3) & "       " & Lpad(vr_lote1, "0", 3) & "        " & vr_fecha2.ToString("dd/MM/yyyy") & "        " & vr_fecha2.ToString("HH:mm") & "         " & Lpad(vr_unidad1, "0", 3) & "|"
                If Convert.ToInt32(vr_lote2) > 0 Then
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante2, "0", 3) & "       " & Lpad(vr_lote2, "0", 3) & "       " & vr_fecha3.ToString("dd/MM/yyyy") & "        " & vr_fecha3.ToString("HH:mm") & "         " & Lpad(vr_unidad2, "0", 3) & "|"
                End If
                If Convert.ToInt32(vr_lote3) > 0 Then
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante3, "0", 3) & "       " & Lpad(vr_lote3, "0", 3) & "       " & vr_fecha4.ToString("dd/MM/yyyy") & "        " & vr_fecha4.ToString("HH:mm") & "         " & Lpad(vr_unidad3, "0", 3) & "|"
                End If
                If Convert.ToInt32(vr_lote4) > 0 Then
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204,VMULT1|" & Lpad(vr_pante4, "0", 3) & "       " & Lpad(vr_lote4, "0", 3) & "       " & vr_fecha5.ToString("dd/MM/yyyy") & "        " & vr_fecha5.ToString("HH:mm") & "         " & Lpad(vr_unidad4, "0", 3) & "|"
                End If
            End If
            '--------------genera detalle
            vr_DETALLE = ""
            If ((vr_tipo = "C") Or (vr_tipo = "G")) Then
                vr_CONN = New SqlCeConnection("Data Source = " & vr_DirectorioDeAplicacion & vr_NOMBREBD)
                vr_QUERY = New SqlCeCommand("select FILA, POSICION, CORTADOR, UNIDAD, FECHA_CORTE, EQUIVALENCIA, CONTRATISTA from TB_DETALLE_ENVIO where envio ='" + Reporte.Text + "' AND serie = '" + serie_env.Text.ToUpper + "';", vr_CONN)
                Dim vr_dr3 As SqlCeDataReader = Nothing
                Try
                    vr_CONN.Open()
                    vr_dr3 = vr_QUERY.ExecuteReader
                    While vr_dr3.Read
                        If vr_dr3(0).ToString <> "" And vr_dr3(1).ToString <> "" And vr_dr3(2).ToString <> "" And vr_dr3(3).ToString <> "" And vr_dr3(4).ToString <> "" And vr_dr3(5).ToString <> "" Then
                            If vr_DETALLE <> "" Then
                                vr_DETALLE = vr_DETALLE + Lpad(vr_dr3(0).ToString, "0", 3) + Lpad(vr_dr3(1).ToString, "0", 3) + Lpad(vr_dr3(2).ToString, "0", 6) + Lpad(vr_dr3(3).ToString, "0", 3) + Lpad(Replace(vr_dr3(4).ToString, "/", ""), "0", 8) + Lpad(vr_dr3(5).ToString, "0", 6).ToUpper + Lpad(vr_dr3(6).ToString, "0", 6)
                            Else
                                vr_DETALLE = Lpad(vr_dr3(0).ToString, "0", 3) + Lpad(vr_dr3(1).ToString, "0", 3) + Lpad(vr_dr3(2).ToString, "0", 6) + Lpad(vr_dr3(3).ToString, "0", 3) + Lpad(Replace(vr_dr3(4).ToString, "/", ""), "0", 8) + Lpad(vr_dr3(5).ToString, "0", 6).ToUpper + Lpad(vr_dr3(6).ToString, "0", 6)
                            End If
                        ElseIf vr_dr3(0).ToString = "" And vr_dr3(1).ToString = "" And vr_dr3(2).ToString = "" And vr_dr3(3).ToString = "" And vr_dr3(5).ToString = "" And vr_dr3(4).ToString <> "" Then
                            vr_DETALLE = Lpad(vr_dr3(4).ToString, "0", 8)
                        End If
                    End While
                    vr_dr3.Close()
                Catch ex As Exception
                    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                               "Favor de reportarlo.")
                End Try
                vr_CONN.Close()
            ElseIf vr_tipo = "M" Then
                vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                vr_QUERY = New SqlCeCommand("select ALZADORA, TRACTOR, CARRETAS, CORTADOR, OPERADOR_TRA from TB_DETALLE_ENVIO where envio =" & Convert.ToInt32(Reporte.Text) & " AND serie = '" + serie_env.Text.ToUpper + "' ORDER BY DETALLE;", vr_CONN)
                Dim vr_dr3 As SqlCeDataReader = Nothing
                Try
                    vr_CONN.Open()
                    vr_dr3 = vr_QUERY.ExecuteReader
                    While vr_dr3.Read
                        If vr_dr3(0).ToString <> "" And vr_dr3(1).ToString <> "" And vr_dr3(2).ToString <> "" And vr_dr3(3).ToString <> "" And vr_dr3(4).ToString <> "" Then
                            If vr_DETALLE <> "" Then
                                vr_DETALLE = vr_DETALLE + Lpad(vr_dr3(0).ToString, "0", 3) + Lpad(vr_dr3(1).ToString, "0", 3) + Lpad(vr_dr3(2).ToString, "0", 3) + Lpad(vr_dr3(3).ToString, "0", 6) + Lpad(vr_dr3(4).ToString, "0", 6)
                            Else
                                vr_DETALLE = Lpad(vr_dr3(0).ToString, "0", 3) + Lpad(vr_dr3(1).ToString, "0", 3) + Lpad(vr_dr3(2).ToString, "0", 3) + Lpad(vr_dr3(3).ToString, "0", 6) + Lpad(vr_dr3(4).ToString, "0", 6)                                
                            End If
                        ElseIf vr_dr3(0).ToString = "" And vr_dr3(1).ToString = "" And vr_dr3(2).ToString = "" And vr_dr3(3).ToString = "" And vr_dr3(4).ToString = "" Then
                            vr_DETALLE = Lpad(vr_dr3(1).ToString, "0", 8)
                        End If
                    End While
                    vr_dr3.Close()
                Catch ex As Exception
                    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                               "Favor de reportarlo.")
                End Try
                vr_CONN.Close()
            ElseIf vr_tipo = "T" Or vr_tipo = "L" Then
                vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                vr_QUERY = New SqlCeCommand("select CORTADOR, FECHA_CORTE,  EQUIVALENCIA, fila, posicion, unidad from TB_DETALLE_ENVIO where envio =" & Convert.ToInt32(Reporte.Text) & " AND serie = '" + serie_env.Text.ToUpper + "' ORDER BY DETALLE;", vr_CONN)
                Dim dr3 As SqlCeDataReader = Nothing
                Try
                    vr_CONN.Open()
                    dr3 = vr_QUERY.ExecuteReader
                    While dr3.Read
                        If dr3(0).ToString <> "" And dr3(1).ToString <> "" And dr3(2).ToString <> "" Then
                            If vr_DETALLE <> "" Then
                                If vr_tipo = "T" Then
                                    vr_DETALLE = vr_DETALLE + Lpad(dr3(0).ToString, "0", 6) + Lpad(dr3(2).ToString, "0", 6).ToUpper + Lpad(Replace(dr3(1).ToString, "/", ""), "0", 8)
                                Else
                                    vr_DETALLE = vr_DETALLE + Lpad(dr3(0).ToString, "0", 6) + Lpad(dr3(2).ToString, "0", 6).ToUpper + Lpad(Replace(dr3(1).ToString, "/", ""), "0", 8) + Lpad(dr3(3).ToString, "0", 3) + Lpad(dr3(4).ToString, "0", 3) + Lpad(dr3(5).ToString, "0", 3)
                                End If
                            Else
                                If vr_tipo = "T" Then
                                    vr_DETALLE = vr_DETALLE + Lpad(dr3(0).ToString, "0", 6) + Lpad(dr3(2).ToString, "0", 6).ToUpper + Lpad(Replace(dr3(1).ToString, "/", ""), "0", 8)
                                Else
                                    vr_DETALLE = vr_DETALLE + Lpad(dr3(0).ToString, "0", 6) + Lpad(dr3(2).ToString, "0", 6).ToUpper + Lpad(Replace(dr3(1).ToString, "/", ""), "0", 8) + Lpad(dr3(3).ToString, "0", 3) + Lpad(dr3(4).ToString, "0", 3) + Lpad(dr3(5).ToString, "0", 3)
                                End If
                                'vr_DETALLE = Lpad(dr3(0).ToString, "0", 6) + Lpad(dr3(2).ToString, "0", 6).ToUpper + Lpad(Replace(dr3(1).ToString, "/", ""), "0", 8)

                            End If
                            ElseIf dr3(0).ToString = "" And dr3(2).ToString = "" And dr3(1).ToString <> "" Then
                                vr_DETALLE = Lpad(dr3(1).ToString, "0", 8)
                            End If
                    End While
                    dr3.Close()
                Catch ex As Exception
                    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                               "Favor de reportarlo.")
                End Try
                vr_CONN.Close()
            End If
            '--------------termino detalle

            vr_coordenada = vr_coordenada + 30
            If ((vr_tipo = "C") Or (vr_tipo = "G")) Then
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR         UNADAS      FECHA CORTE      EQUIVALENCIA|"
                'MsgBox(detalle.Text.Length / 12)
                'salto de linea comentado porque no existe 
                If vr_DETALLE.Length > 8 Then
                    vr_corte = (vr_DETALLE.Length / 35)
                    vr_salto = 1
                    vr_lectura = 0
                    'MsgBox(corte)
                    vr_total_detalle = 0
                    While vr_salto <= vr_corte
                        vr_linea = ""
                        vr_coordenada = vr_coordenada + 30
                        'salto de linea comentado porque no existe
                        vr_linea = vr_DETALLE.Substring(vr_lectura * 35, 35)
                        'MsgBox("linea: " & linea)
                        'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                        vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |" & vr_linea.Substring(0, 3) & "    " & vr_linea.Substring(3, 3) & "        " & vr_linea.Substring(6, 6) & "  " & vr_linea.Substring(29, 6) & "     " & vr_linea.Substring(12, 3) & "      " & vr_linea.Substring(15, 2) & "/" & vr_linea.Substring(17, 2) & "/" & vr_linea.Substring(19, 4) & "       " & vr_linea.Substring(23, 6) & "|"
                        vr_total_detalle = vr_total_detalle + Convert.ToInt32(vr_linea.Substring(12, 3))
                        vr_salto = vr_salto + 1
                        vr_lectura = vr_lectura + 1
                    End While
                Else
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |                                                  " & detalle.Substring(0, 2) & "/" & detalle.Substring(2, 2) & "/" & detalle.Substring(4, 4) & "             |"
                End If
            ElseIf ((vr_tipo = "L") Or (vr_tipo = "T")) Then
                If vr_tipo = "T" Then
                    If vr_DETALLE.Length > 8 Then
                        vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |CORTADOR      EQUIVALENCIA      FECHA CORTE|"
                        'MsgBox(detalle.Text.Length / 12)
                        'salto de linea comentado porque no existe
                        vr_corte = (detalle.Length / 20)
                        vr_salto = 1
                        vr_lectura = 0
                        'MsgBox(corte)
                        While vr_salto <= vr_corte
                            vr_linea = ""
                            vr_coordenada = vr_coordenada + 30
                            'salto de linea comentado porque no existe
                            vr_linea = vr_DETALLE.Substring(vr_lectura * 20, 20)
                            'MsgBox("linea: " & linea)
                            'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |" & vr_linea.Substring(0, 6) & "        " & vr_linea.Substring(6, 6) & "            " & vr_linea.Substring(12, 2) & "/" & vr_linea.Substring(14, 2) & "/" & vr_linea.Substring(16, 4) & "|"
                            vr_salto = vr_salto + 1
                            vr_lectura = vr_lectura + 1
                        End While
                    End If
                ElseIf vr_tipo = "L" Then
                    If vr_DETALLE.Length > 8 Then
                        vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |FILA   POSICION  CORTADOR  QUINTALES  EQUIVALENCIA  FECHA CORTE|"
                        'MsgBox(detalle.Text.Length / 12)
                        'salto de linea comentado porque no existe
                        vr_corte = (detalle.Length / 20)
                        vr_salto = 1
                        vr_lectura = 0
                        'MsgBox(corte)
                        'While vr_salto <= vr_corte
                        vr_linea = ""
                        vr_coordenada = vr_coordenada + 30
                        'salto de linea comentado porque no existe
                        vr_linea = vr_DETALLE
                        'MsgBox("linea: " & linea)
                        'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                        vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |" & vr_linea.Substring(20, 3) & "      " & vr_linea.Substring(23, 3) & "      " & vr_linea.Substring(0, 6) & "      " & vr_linea.Substring(26, 3) & "      " & vr_linea.Substring(6, 6) & "        " & vr_linea.Substring(12, 2) & "/" & vr_linea.Substring(14, 2) & "/" & vr_linea.Substring(16, 4) & "|"
                        vr_salto = vr_salto + 1
                        vr_lectura = vr_lectura + 1
                        'End While
                    End If
                    vr_total_detalle = vr_total_unidades
                Else
                    vr_coordenada = vr_coordenada + 30
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |                                " & detalle.Substring(0, 2) & "/" & detalle.Substring(2, 2) & "/" & detalle.Substring(4, 4) & "|"
                End If
            ElseIf (vr_tipo = "M") Then
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |CORTADORA      TRACTOR      CARRETAS      O. CORTADORA      O. TRACTOR|"
                vr_corte = (vr_DETALLE.Length / 21)
                vr_salto = 1
                vr_lectura = 0
                vr_total_detalle = 0
                While vr_salto <= vr_corte
                    vr_linea = ""
                    vr_coordenada = vr_coordenada + 30
                    'salto de linea comentado porque no existe
                    vr_linea = vr_DETALLE.Substring(vr_lectura * 21, 21)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |" & vr_linea.Substring(0, 3) & "            " & vr_linea.Substring(3, 3) & "           " & vr_linea.Substring(6, 3) & "           " & vr_linea.Substring(9, 6) & "           " & vr_linea.Substring(15, 6) & "|"
                    ' total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    vr_salto = vr_salto + 1
                    vr_lectura = vr_lectura + 1
                End While
                vr_total_detalle = vr_total_unidades
            End If
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |TOTAL " & vr_UNIDADES & ": " & vr_total_detalle & " |"
            vr_coordenada = vr_coordenada + 30
            vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |ENVIERO    : " & Lpad(vr_enviero, "0", 6) & " |"
            If (vr_tipo = "L") Then
                vr_coordenada = vr_coordenada + 30
                vr_IMP &= "@" & vr_coordenada & ",50:MF204, VMULT1 |TIPO    : " & vr_texto & " |"
            End If
            vr_impresiones = vr_impresiones + 1
            vr_coordenada = vr_coordenada + 50
            vr_IMP &= "@" & vr_coordenada & ", 50:MF204, VMULT1 | IMPRESION NUMERO : " & vr_impresiones & "|"
            vr_coordenada = vr_coordenada + 50
            vr_IMP &= "@" & vr_coordenada & ", 50:MF204, VMULT1 | UBICACION : " + vr_latitud + ", " + vr_longitud + ", " + Replace(Replace(vr_estadof, "F", "False"), "T", "True") + "|"
            vr_coordenada = vr_coordenada + 50
            vr_IMP &= "@" & vr_coordenada & ", 50:MF204, VMULT1 | REIMPRESION AUTORIZADA POR: " & usuario.Text & " en la fecha " & Now.ToString("dd/MM/yyyy HH:mm") & "|"
            vr_coordenada = vr_coordenada + 50

            If ((vr_tipo = "C") Or (vr_tipo = "G")) Then 'ticket = boleta de transporte'
                vr_GENERADO = Replace(Lpad(vr_latitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_longitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_estadof, "0", 2), Chr(39), "!") + Lpad(vr_empresa, "0", 4) + Lpad(vr_serie_preparada, "0", 4) + Lpad(vr_numero_archivo.ToString, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(vr_finca, "0", 4) + Lpad(vr_frente, "0", 4) + Lpad(vr_trans, "0", 4) + Lpad(vr_vehi, "0", 3) + Lpad(vr_pilo, "0", 3) + Lpad(vr_plata, "0", 3) + Lpad(vr_contratista, "0", 4) + Lpad(vr_enviero, "0", 6) + Lpad(vr_lote1, "0", 3) + Lpad(vr_lote2, "0", 3) + Lpad(vr_lote3, "0", 3) + Lpad(vr_lote4, "0", 3) + Lpad(vr_pante1, "0", 3) + Lpad(vr_pante2, "0", 3) + Lpad(vr_pante3, "0", 3) + Lpad(vr_pante4, "0", 3) + Lpad(vr_unidad1, "0", 3) + Lpad(vr_unidad2, "0", 3) + Lpad(vr_unidad3, "0", 3) + Lpad(vr_unidad4, "0", 3) + Lpad(vr_fechaq1, "0", 8) + Lpad(vr_fechaq2, "0", 8) + Lpad(vr_fechaq3, "0", 8) + Lpad(vr_fechaq4, "0", 8) + Lpad(vr_horaq1, "0", 4) + Lpad(vr_horaq2, "0", 4) + Lpad(vr_horaq3, "0", 4) + Lpad(vr_horaq4, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(vr_grupo, "0", 3).ToUpper + Lpad(vr_ticket, "0", 6) + Lpad(vr_zona, "0", 2) + Lpad(vr_cole, "0", 3) + Lpad(vr_alzador, "0", 6) + Lpad(vr_tractor, "0", 6) + Lpad(vr_opera_alz, "0", 6) + Lpad(vr_opera_tra, "0", 6) + Lpad(vr_ruta, "0", 3) + vr_DETALLE
            ElseIf (vr_tipo = "L") Then
                If vr_flete = "P" Then
                    vr_texto = "PROPIO"
                Else
                    vr_texto = "FLETERO"
                End If
                vr_GENERADO = Replace(Lpad(vr_latitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_longitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_estadof, "0", 2), Chr(39), "!") + Lpad(vr_empresa, "0", 4) + Lpad(vr_serie_preparada, "0", 4) + Lpad(vr_numero_archivo.ToString, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(vr_finca, "0", 4) + Lpad(vr_frente, "0", 4) + Lpad(vr_trans, "0", 4) + Lpad(vr_vehi, "0", 3) + Lpad(vr_pilo, "0", 3) + Lpad(vr_plata, "0", 3) + Lpad(vr_contratista, "0", 4) + Lpad(vr_enviero, "0", 6) + Lpad(vr_lote1, "0", 3) + Lpad(vr_lote2, "0", 3) + Lpad(vr_lote3, "0", 3) + Lpad(vr_lote4, "0", 3) + Lpad(vr_pante1, "0", 3) + Lpad(vr_pante2, "0", 3) + Lpad(vr_pante3, "0", 3) + Lpad(vr_pante4, "0", 3) + Lpad(vr_unidad1, "0", 3) + Lpad(vr_unidad2, "0", 3) + Lpad(vr_unidad3, "0", 3) + Lpad(vr_unidad4, "0", 3) + Lpad(vr_fechaq1, "0", 8) + Lpad(vr_fechaq2, "0", 8) + Lpad(vr_fechaq3, "0", 8) + Lpad(vr_fechaq4, "0", 8) + Lpad(vr_horaq1, "0", 4) + Lpad(vr_horaq2, "0", 4) + Lpad(vr_horaq3, "0", 4) + Lpad(vr_horaq4, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(vr_grupo, "0", 3).ToUpper + Lpad(vr_ticket, "0", 6) + Lpad(vr_ruta, "0", 3) + Lpad(vr_flete, "0", 1)
            ElseIf (vr_tipo = "M") Then
                vr_GENERADO = Replace(Lpad(vr_latitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_longitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_estadof, "0", 2), Chr(39), "!") + Lpad(vr_empresa, "0", 4) + Lpad(vr_serie_preparada, "0", 4) + Lpad(vr_numero_archivo.ToString, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(vr_finca, "0", 4) + Lpad(vr_frente, "0", 4) + Lpad(vr_trans, "0", 4) + Lpad(vr_vehi, "0", 3) + Lpad(vr_pilo, "0", 3) + Lpad(vr_plata, "0", 3) + Lpad(vr_contratista, "0", 4) + Lpad(vr_enviero, "0", 6) + Lpad(vr_lote1, "0", 3) + Lpad(vr_lote2, "0", 3) + Lpad(vr_lote3, "0", 3) + Lpad(vr_lote4, "0", 3) + Lpad(vr_pante1, "0", 3) + Lpad(vr_pante2, "0", 3) + Lpad(vr_pante3, "0", 3) + Lpad(vr_pante4, "0", 3) + Lpad(vr_unidad1, "0", 3) + Lpad(vr_unidad2, "0", 3) + Lpad(vr_unidad3, "0", 3) + Lpad(vr_unidad4, "0", 3) + Lpad(vr_fechaq1, "0", 8) + Lpad(vr_fechaq2, "0", 8) + Lpad(vr_fechaq3, "0", 8) + Lpad(vr_fechaq4, "0", 8) + Lpad(vr_horaq1, "0", 4) + Lpad(vr_horaq2, "0", 4) + Lpad(vr_horaq3, "0", 4) + Lpad(vr_horaq4, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(vr_grupo, "0", 3).ToUpper + Lpad(vr_ticket, "0", 6) + Lpad(vr_ruta, "0", 3) + Lpad(vr_cole, "0", 3) + vr_DETALLE
            ElseIf (vr_tipo = "T") Then
                vr_GENERADO = Replace(Lpad(vr_latitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_longitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_estadof, "0", 2), Chr(39), "!") + Lpad(vr_empresa, "0", 4) + Lpad(vr_serie_preparada, "0", 4) + Lpad(vr_numero_archivo.ToString, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(vr_finca, "0", 4) + Lpad(vr_frente, "0", 4) + Lpad(vr_trans, "0", 4) + Lpad(vr_vehi, "0", 3) + Lpad(vr_pilo, "0", 3) + Lpad(vr_plata, "0", 3) + Lpad(vr_contratista, "0", 4) + Lpad(vr_enviero, "0", 6) + Lpad(vr_lote1, "0", 3) + Lpad(vr_lote2, "0", 3) + Lpad(vr_lote3, "0", 3) + Lpad(vr_lote4, "0", 3) + Lpad(vr_pante1, "0", 3) + Lpad(vr_pante2, "0", 3) + Lpad(vr_pante3, "0", 3) + Lpad(vr_pante4, "0", 3) + Lpad(vr_unidad1, "0", 3) + Lpad(vr_unidad2, "0", 3) + Lpad(vr_unidad3, "0", 3) + Lpad(vr_unidad4, "0", 3) + Lpad(vr_fechaq1, "0", 8) + Lpad(vr_fechaq2, "0", 8) + Lpad(vr_fechaq3, "0", 8) + Lpad(vr_fechaq4, "0", 8) + Lpad(vr_horaq1, "0", 4) + Lpad(vr_horaq2, "0", 4) + Lpad(vr_horaq3, "0", 4) + Lpad(vr_horaq4, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(vr_grupo, "0", 3).ToUpper + Lpad(vr_ticket, "0", 6) + Lpad(vr_zona, "0", 2) + vr_DETALLE
            ElseIf (vr_tipo = "U") Then
                vr_GENERADO = Replace(Lpad(vr_latitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_longitud, "0", 12), Chr(39), "!") + Replace(Lpad(vr_estadof, "0", 2), Chr(39), "!") + Lpad(vr_empresa, "0", 4) + Lpad(vr_serie_preparada, "0", 4) + Lpad(vr_numero_archivo.ToString, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(vr_finca, "0", 4) + Lpad(vr_frente, "0", 4) + Lpad(vr_trans, "0", 4) + Lpad(vr_vehi, "0", 3) + Lpad(vr_pilo, "0", 3) + Lpad(vr_plata, "0", 3) + Lpad(vr_contratista, "0", 4) + Lpad(vr_enviero, "0", 6) + Lpad(vr_lote1, "0", 3) + Lpad(vr_lote2, "0", 3) + Lpad(vr_lote3, "0", 3) + Lpad(vr_lote4, "0", 3) + Lpad(vr_pante1, "0", 3) + Lpad(vr_pante2, "0", 3) + Lpad(vr_pante3, "0", 3) + Lpad(vr_pante4, "0", 3) + Lpad(vr_unidad1, "0", 3) + Lpad(vr_unidad2, "0", 3) + Lpad(vr_unidad3, "0", 3) + Lpad(vr_unidad4, "0", 3) + Lpad(vr_fechaq1, "0", 8) + Lpad(vr_fechaq2, "0", 8) + Lpad(vr_fechaq3, "0", 8) + Lpad(vr_fechaq4, "0", 8) + Lpad(vr_horaq1, "0", 4) + Lpad(vr_horaq2, "0", 4) + Lpad(vr_horaq3, "0", 4) + Lpad(vr_horaq4, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(vr_grupo, "0", 3).ToUpper + vr_DETALLE
            End If

            vr_IMP &= "@" & vr_coordenada & ", 0 :PD417, YDIM 6, XDIM 1 COLUMNS 12, SECURITY 3 |" & vr_GENERADO & "|"
            vr_IMP &= "}" & "{AHEAD:125}" & "{LP}"
            BTPRINT.Write(vr_IMP)
            BTPRINT.Close()
            If vr_impresiones = 1 Then
                vr_impresiones = vr_impresiones
            Else
                vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                vr_QUERY = New SqlCeCommand("UPDATE TB_ENVIOS SET IMPRESIONES = " & Convert.ToInt32(vr_impresiones) & " WHERE ENVIO = " & Convert.ToInt32(vr_numero_archivo) & " AND SERIE = '" & Convert.ToString(vr_serie_preparada) & "';", vr_CONN)
                Dim vr_REGISTROS As Integer
                Try
                    vr_CONN.Open()
                    If vr_CONN.State = Data.ConnectionState.Open Then
                        vr_REGISTROS = vr_QUERY.ExecuteNonQuery
                    End If
                Catch ex As Exception
                    MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
                vr_CONN.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtLongitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongitud.TextChanged
        estado = 1
    End Sub

    Private Sub babrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles babrir.Click
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASETURNO)
        Dim QUERY = New SqlCeCommand("SELECT MAX(TURNO)+1 FROM TB_TURNO", CONN)
        Dim dr As SqlCeDataReader = Nothing
        Dim TURNOA As Integer = 0
        Try
            CONN.Open()
            dr = QUERY.ExecuteReader()
            While dr.Read()
                If dr(0).Equals(mingo) Then
                    TURNOA = 1
                Else
                    TURNOA = dr(0).ToString
                End If
            End While
            QUERY = New SqlCeCommand("INSERT INTO TB_TURNO (TURNO, FINI, ESTADO, USUARIO_A) VALUES (" & TURNOA & ", '" + Now() + "', 'A', '" + usuario.Text + "')", CONN)
            QUERY.ExecuteNonQuery()
            Generar.Enabled = True
            MsgBox("Turno Abierto No. " & TURNOA, , "INFORMACION")
            Pic_TurnoWar.Visible = False
            lbl_Turno.Visible = False
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
        bcerrar.Enabled = True
        babrir.Enabled = False
    End Sub

    Private Sub bcerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcerrar.Click
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASETURNO)
        Dim QUERY = New SqlCeCommand("SELECT TURNO FROM TB_TURNO WHERE ESTADO = 'A'", CONN)
        Dim dr As SqlCeDataReader = Nothing
        Dim TURNO As Integer
        Try
            CONN.Open()
            dr = QUERY.ExecuteReader()
            While dr.Read()
                TURNO = dr(0).ToString
            End While
            If SUPER = 0 Then
                QUERY = New SqlCeCommand("UPDATE TB_TURNO SET ESTADO ='C', FFIN = '" + Now().ToString("yyyyMMdd HH:mm") + "', USUARIO_C = '" + usuario.Text + "' WHERE TURNO = " & TURNO, CONN)
            Else
                QUERY = New SqlCeCommand("UPDATE TB_TURNO SET ESTADO ='C', FFIN = '" + Now().ToString("yyyyMMdd HH:mm") + "', USUARIO_C = '" + usuario.Text + "', OBSERVACION = '" + clobservaciones.SelectedItem + "' WHERE TURNO = " & TURNO, CONN)
            End If
            QUERY.ExecuteNonQuery()
            Generar.Enabled = False
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
        babrir.Enabled = True
        bcerrar.Enabled = False
        If SUPER = 1 Then
            lobservacion.Visible = False
            clobservaciones.Visible = False
            babrir.Enabled = False
        End If
        MsgBox("Turno Cerrado No. " & TURNO, , "Informacion")

    End Sub

    Private Sub verificar_turno()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASETURNO)
        Dim QUERY = New SqlCeCommand("SELECT TURNO, usuario_a FROM TB_TURNO WHERE ESTADO = 'A'", CONN)
        Dim dr As SqlCeDataReader = Nothing
        Try
            CONN.Open()
            dr = QUERY.ExecuteReader()
            While dr.Read()
                If dr(0).Equals(mingo) Then
                    turnop = 0
                    usua = ""
                Else
                    turnop = Convert.ToInt32(dr(0).ToString)
                    usua = dr(1).ToString
                End If
            End While
            If turnop = 0 And SUPER = 0 Then
                babrir.Enabled = True
                bcerrar.Enabled = False
                MsgBox("Debe abrir turno para poder ingresar envios ", , "Informacion ")
                Generar.Enabled = False
                buturno.Enabled = True
                valida2 = 1
                Pic_TurnoWar.Visible = True
                lbl_Turno.Visible = True
            ElseIf turnop > 0 And SUPER = 1 Then
                babrir.Enabled = False
                bcerrar.Enabled = True
                Generar.Enabled = False
                lobservacion.Visible = True
                clobservaciones.Visible = True
                btturno.Enabled = True
                buturno.Enabled = True
                valida2 = 2
            ElseIf turnop > 0 And SUPER = 0 Then
                If usua = usuario.Text Then
                    babrir.Enabled = False
                    bcerrar.Enabled = True
                    Generar.Enabled = True
                    buturno.Enabled = True
                    valida2 = 3
                    Pic_TurnoWar.Visible = False
                    lbl_Turno.Visible = False
                Else
                    MsgBox("Ya hay un turno abierto con otro usuario", , "Informacion")
                    'If gps.Opened Then gps.Close()
                    Me.Dispose()
                    Me.Close()
                    valida2 = 4
                    Pic_TurnoWar.Visible = True
                    lbl_Turno.Text = "Cierre Turno"
                    lbl_Turno.Visible = True
                End If
            ElseIf turnop = 0 And SUPER = 1 Then
                babrir.Enabled = False
                bcerrar.Enabled = False
                buturno.Enabled = True
                btturno.Enabled = True
                valida2 = 5
            End If
            QUERY.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
                        "Favor de reportarlo.")
        End Try
        CONN.Close()
    End Sub

    Private Sub buturno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buturno.Click
        If SUPER = 1 Then
            imprime_ultimo_turno(1)
        Else
            imprime_ultimo_turno(0)
        End If
    End Sub
    Private Sub imprime_ultimo_turno(ByVal tipo As Integer)
        Dim conn = New SqlCeConnection("Data source = " & DirectorioDeAplicacion & BASETURNO)
        Dim query = New SqlCeCommand("", conn)
        Dim n_turno As Integer = 0
        Dim fecha_ini As Date = Nothing
        Dim fecha_fin As Date = Nothing
        Dim usuario_a As String = Nothing
        Dim usuario_c As String = Nothing
        Dim observacion As String = Nothing
        Dim n_impresion As Integer = 1
        Dim b_cont_impresion As Integer = Nothing
        Dim dr As SqlCeDataReader = Nothing
        Dim contador_envios As Integer = 0
        If tipo = 1 Then
            query = New SqlCeCommand("select max(turno) from tb_turno where estado = 'C'", conn)
        ElseIf tipo = 0 Then
            query = New SqlCeCommand("select max(turno) from tb_turno where estado = 'C' AND usuario_a = " + usuario.Text, conn)
        Else
            MsgBox("No hay parametros correctos para la funcion", , "Error")
        End If
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dr = query.ExecuteReader
            While dr.Read
                n_turno = Convert.ToInt32(dr(0).ToString)
            End While
            query = New SqlCeCommand("SELECT FINI, FFIN, USUARIO_A, USUARIO_C, OBSERVACION, IMPRESION FROM TB_TURNO WHERE ESTADO = 'C' AND TURNO = " & n_turno, conn)
            dr = query.ExecuteReader
            While dr.Read
                fecha_ini = dr(0)
                fecha_fin = dr(1)
                usuario_a = dr(2)
                usuario_c = dr(3)
                If dr(4).Equals(mingo) Then
                    observacion = "Cierre Normal"
                Else
                    observacion = dr(4).ToString
                End If
                If dr(5).Equals(mingo) Then
                    n_impresion = n_impresion
                Else
                    n_impresion = Convert.ToInt32(dr(5).ToString) + 1
                End If
            End While

        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & " Favor de Reportarlo", , "Error")
        End Try
        If BTPRINT.IsOpen Then
            BTPRINT.Close()
        End If

        Dim enca As String = Nothing
        Dim TCOORDENADA As Integer = 0
        Try
            BTPRINT.Open()
            BTPRINT.WriteTimeout = 9000
            enca = Chr(27) & "EZ" & "{PRINT:" & "@" & TCOORDENADA & ",250:MF107,VMULT2|INGENIO EL PILAR, S. A.|"
            TCOORDENADA = TCOORDENADA + 70
            enca &= "@" & TCOORDENADA & ", 50:MF107, VMULT2|REPORTE DE ULTIMO TURNO CERRADO|"
            TCOORDENADA = TCOORDENADA + 70
            enca &= "@" & TCOORDENADA & ", 50:MF204, VMULT2|NUMERO TURNO: " & n_turno & "|"
            TCOORDENADA = TCOORDENADA + 70
            enca &= "@" & TCOORDENADA & ", 50:MF204, VMULT2|USUARIO APERTURA: " + usuario_a + "  USUARIO CIERRA: " + usuario_c + "|"
            TCOORDENADA = TCOORDENADA + 50
            enca &= "@" & TCOORDENADA & ", 50:MF204, VMULT2|FECHA INICIO TURNO: " & fecha_ini.ToString("dd/MM/yyyy hh:mm:ss tt") & "   FECHA FIN TURNO: " & fecha_fin.ToString("dd/MM/yyyy hh:mm:ss tt") & "|"
            TCOORDENADA = TCOORDENADA + 50
            enca &= "@" & TCOORDENADA & ", 50:MF204, VMULT2|OBSERVACIONES DEL TURNO: " & observacion & "|"
            enca &= "}" & "{AHEAD:12}" & "{LP}"
            BTPRINT.Write(enca)
            TCOORDENADA = 0
            Dim QUERY2 As New SqlCeCommand("SELECT SERIE, REPORTE, FECHA_ENVIO, ID_TRANSPORTISTA, ID_VEHICULO, ID_FINCA FROM TB_DETALLE_TURNO WHERE TURNO = " & n_turno, conn)
            Dim DR2 As SqlCeDataReader = Nothing
            Dim CUERPO As String = Nothing
            DR2 = QUERY2.ExecuteReader
            TCOORDENADA = TCOORDENADA + 50
            CUERPO = Chr(27) & "EZ" & "{PRINT:" & "@" & TCOORDENADA & ", 50:MF204, VMULT1|SERIE      REPORTE        FECHA ENVIO         TRANSP-VEHICULO     FINCA |"
            While DR2.Read
                TCOORDENADA = TCOORDENADA + 50
                contador_envios = contador_envios + 1
                'CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|" + Lpad(DR2(0).ToString, " ", 5) + "      " & Lpad(DR2(1).ToString, "0", 10) & "|"
                CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|" + Lpad(DR2(0).ToString, " ", 5) + "      " & Lpad(DR2(1).ToString, "0", 10) & "     " & Lpad(DR2(2).ToString, ".", 18) & "      " & Lpad(DR2(3).ToString, "0", 4) & "-" & Lpad(DR2(4).ToString, "0", 3) & "         " & Lpad(DR2(5).ToString, "0", 3) & "|"
            End While
            TCOORDENADA = TCOORDENADA + 50
            CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|TOTAL DE ENVIOS:      " & contador_envios & "|"
            TCOORDENADA = TCOORDENADA + 50
            CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|USUARIO QUE IMPRIME " + usuario.Text + " FECHA IMPRESION " + Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "|"
            TCOORDENADA = TCOORDENADA + 50
            CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|NUMERO DE IMPRESION " & n_impresion & "|"
            TCOORDENADA = TCOORDENADA + 100
            CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1| |"
            CUERPO &= "}" & "{AHEAD:12}" & "{LP}"
            query = New SqlCeCommand("UPDATE TB_TURNO SET IMPRESION = " & n_impresion & " WHERE TURNO = " & n_turno & " AND ESTADO = 'C'", conn)
            Dim RESULTADO As Integer = Nothing
            RESULTADO = query.ExecuteNonQuery
            conn.Close()
            BTPRINT.Write(CUERPO)
            BTPRINT.Close()
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & " Favor de reportarlo.", , "Error")
        End Try
    End Sub
    Private Sub imprime_todo_turno(ByVal tipo As Integer)
        Dim conn = New SqlCeConnection("Data source = " & DirectorioDeAplicacion & BASETURNO)
        Dim query = New SqlCeCommand("", conn)
        Dim n_turno As Integer = 0
        Dim fecha_ini As Date = Nothing
        Dim fecha_fin As Date = Nothing
        Dim usuario_a As String = Nothing
        Dim usuario_c As String = Nothing
        Dim observacion As String = Nothing
        Dim n_impresion As Integer = Nothing
        Dim dr As SqlCeDataReader = Nothing
        Dim CUERPO As String = Nothing
        Dim itt_valor As Integer = 0
        Dim valor As Integer = 0
        If BTPRINT.IsOpen Then
            BTPRINT.Close()
        End If

        Dim enca As String = Nothing
        Dim TCOORDENADA As Integer = 0
        Try
            BTPRINT.Open()
            BTPRINT.WriteTimeout = 9000
            enca = Chr(27) & "EZ" & "{PRINT:" & "@" & TCOORDENADA & ",250:MF107,VMULT2|INGENIO EL PILAR, S. A.|"
            TCOORDENADA = TCOORDENADA + 70
            enca &= "@" & TCOORDENADA & ", 50:MF107, VMULT2|REPORTE DE TODO TURNO CERRADO|"
            ' TCOORDENADA = TCOORDENADA + 70
            'enca &= "@" & TCOORDENADA & ", 50:MF107, VMULT2|NUMERO TURNO: " & n_turno & "|"
            'TCOORDENADA = TCOORDENADA + 70
            'enca &= "@" & TCOORDENADA & ", 50:MF107, VMULT2|USUARIO APERTURA: " + usuario_a + "  USUARIO CIERRA: " + usuario_c + "|"
            'TCOORDENADA = TCOORDENADA + 50
            'enca &= "@" & TCOORDENADA & ", 50:MF107, VMULT2|FECHA INICIO TURNO: " & fecha_ini.ToString("dd/MM/yyyy hh:mm:ss tt") & "   FECHA FIN TURNO: " & fecha_fin.ToString("dd/MM/yyyy hh:mm:ss tt") & "|"
            'TCOORDENADA = TCOORDENADA + 50
            'enca &= "@" & TCOORDENADA & ", 50:MF107, VMULT2|OBSERVACIONES DEL TURNO: " & observacion & "|"
            enca &= "}" & "{AHEAD:12}" & "{LP}"
            BTPRINT.Write(enca)
            'inicia
            TCOORDENADA = 0
            If tipo = 1 Then
                query = New SqlCeCommand("select turno, fini, ffin, usuario_a, usuario_c, observacion, impresion from tb_turno where estado = 'C' order by turno", conn)
            ElseIf tipo = 0 Then
                query = New SqlCeCommand("select turno, fini, ffin, usuario_a, usuario_c, observacion, impresion from tb_turno where estado = 'C' AND usuario_a = " + usuario.Text + "order by turno", conn)
            Else
                MsgBox("No hay parametros correctos para la funcion", , "Error")
            End If
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                If valor = 0 Then
                    TCOORDENADA = TCOORDENADA + 50
                    CUERPO = Chr(27) & "EZ" & "{PRINT:" & "@" & TCOORDENADA & ",250:MF204, VMULT1||"
                    TCOORDENADA = TCOORDENADA + 70
                    CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT2|NO TURNO   USUARIO A   USUARIO C   FECHA I   FECHA F   OBSERVACION|"
                End If
                valor = valor + 1
                dr = query.ExecuteReader
                While dr.Read
                    n_turno = Convert.ToInt32(dr(0).ToString)
                    fecha_ini = Convert.ToDateTime(dr(1).ToString)
                    fecha_fin = Convert.ToDateTime(dr(2).ToString)
                    usuario_a = dr(3).ToString
                    usuario_c = dr(4).ToString
                    If dr(5).Equals(mingo) Then
                        observacion = "Cierre Normal"
                    Else
                        observacion = dr(5).ToString
                    End If
                    If dr(6).Equals(mingo) Then
                        n_impresion = 0
                    Else
                        n_impresion = Convert.ToInt32(dr(6).ToString) + 1
                    End If


                    TCOORDENADA = TCOORDENADA + 50
                    CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT2|" & Lpad(n_turno, "0", 8) & "   " + Lpad(usuario_a, "0", 9) + "   " + Lpad(usuario_c, "0", 9) + "   " + Lpad(fecha_ini.ToString("dd-MM-yy"), "0", 9) + "   " + Lpad(fecha_fin.ToString("dd-MM-yy"), "0", 9) + "   " + Lpad(observacion, "0", 32) + "|"
                    'aqui comienza detalle
                    Dim QUERY2 As New SqlCeCommand("SELECT SERIE, REPORTE FROM TB_DETALLE_TURNO WHERE TURNO = " & n_turno, conn)
                    Dim query3 As New SqlCeCommand("", conn)
                    Dim DR2 As SqlCeDataReader = Nothing

                    DR2 = QUERY2.ExecuteReader

                    While DR2.Read
                        TCOORDENADA = TCOORDENADA + 50
                        CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|" & Lpad(DR2(0).ToString, " ", 5) & "      " & Lpad(DR2(1).ToString, "0", 10) & "|"
                        If itt_valor > 29 Then
                            CUERPO &= "}" & "{AHEAD:12}" & "{LP}"
                            BTPRINT.Write(CUERPO)
                            TCOORDENADA = 0
                            CUERPO = Chr(27) & "EZ" & "{PRINT:" & "@" & TCOORDENADA & ",250:MF204, VMULT1|SERIE      REPORTE|"
                            itt_valor = 0
                        Else
                            itt_valor = itt_valor + 1
                        End If
                    End While
                    TCOORDENADA = TCOORDENADA + 50
                    'n_impresion = n_impresion + 1
                    CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|NUMERO DE IMPRESION " & n_impresion & "|"
                    query3 = New SqlCeCommand("UPDATE TB_TURNO SET IMPRESION = " & n_impresion & " WHERE TURNO = " & n_turno & " AND ESTADO = 'C'", conn)
                    Dim RESULTADO As Integer = Nothing
                    RESULTADO = query3.ExecuteNonQuery
                    'aqui termina detalle
                End While
            Catch ex As Exception
                MsgBox("Error ocasionado por " & ex.Message & vbCrLf & " Favor de Reportarlo", , "Error")
            End Try
            'termina
            TCOORDENADA = TCOORDENADA + 50
            CUERPO &= "@" & TCOORDENADA & ", 50:MF204, VMULT1|USUARIO QUE IMPRIME " + usuario.Text + " FECHA IMPRESION " & Now.ToString("dd/MM/yyyy hh:mm:ss tt") & "|"
            CUERPO &= "}" & "{AHEAD:12}" & "{LP}"
            BTPRINT.Write(CUERPO)
            conn.Close()
            BTPRINT.Close()
        Catch ex As Exception
            MsgBox("Error ocasionado por " & ex.Message & vbCrLf & " Favor de reportarlo.", , "Error")
        End Try
    End Sub

    Private Sub btturno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btturno.Click
        If SUPER = 1 Then
            imprime_todo_turno(1)
        Else
            imprime_todo_turno(0)
        End If
    End Sub

    Private Sub tipo_envio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Erick Pérez
        '/* Cargo con Cero Ordenes y Croquis de corte
        ' Try
        'Erick Pérez
        '/* Cargo con Cero Ordenes y Croquis de corte
        'Me.TB_FRENTESTableAdapter.Fill(Me.Frentes.TB_FRENTES)

        ocorte.Text = "0"
        Croquis.Text = "0"
        ocorte.Enabled = True
        Croquis.Enabled = True

        '*/ finalizo la carga
        'Catch ex As Exception
        'MsgBox("Error ocasionado por " & ex.Message & vbCrLf & " Favor de reportarlo.", , "Error")
        'End Try
    End Sub


    Private Sub id_ruta_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles id_ruta.LostFocus
        'Dim valor As Integer = Nothing
        'Try
        '    valor = Convert.ToInt32(id_ruta.Text)
        '    Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        '    Dim QUERY = New SqlCeCommand("SELECT count(id_ruta)FROM TB_RUTAS WHERE ID_RUTA = " & valor & " AND ID_FINCA = " & Convert.ToInt32(Id_finca.Text.Trim) & " ;", CONN)
        '    Dim dr As SqlCeDataReader = Nothing
        '    Try
        '        If id_contratista.Text.Length > 0 Then
        '            CONN.Open()
        '            dr = QUERY.ExecuteReader()
        '            While dr.Read()
        '                Contratista.Text = dr(0).ToString
        '            End While
        '        End If
        '    Catch ex As Exception
        '        MsgBox("Error ocasionado por " & ex.Message & vbCrLf & _
        '                    "Favor de reportarlo.")
        '    End Try
        '    CONN.Close()
        '    If valor < 0 Then
        '        MsgBox("ingrese numeros")
        '        id_contratista.Focus()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Ingrese numeros")
        '    id_contratista.Focus()
        '    id_contratista.Text = "0"
        'End Try
        plata.Focus()
    End Sub

    Private Sub presenta_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presenta.CheckStateChanged
        If presenta.CheckState = Windows.Forms.CheckState.Checked Then
            presenta.Checked = True
            fe_quema.Text = ""
            Ho_quema.Text = ""
            fe_quema.Enabled = True
            Ho_quema.Enabled = True
            DateTimePicker1.Enabled = True
            presentanew.Text = "Q"
        Else
            fe_quema.Text = ""
            Ho_quema.Text = ""
            fe_quema.Enabled = False
            Ho_quema.Enabled = False
            DateTimePicker1.Enabled = False
            presentanew.Text = "C"
        End If
    End Sub

    Private Sub Nboleta_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nboleta.LostFocus
        If tipot.Text = "T" Then
            Nboleta.Text = 0
            peri.Focus()
        ElseIf tipot.Text = "L" Then
            If Nboleta.Text = "0" Then
                peri.Focus()
            Else
                f_valida_lectura_manual()
            End If
        Else
            f_valida_lectura_manual()
        End If
    End Sub
    Private Sub equivalencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles equivalencia.SelectedIndexChanged
        If tipot.Text = "G" Or tipot.Text = "C" Then
            If (equivalencia.Text = "F101") Then
                If trato.Checked = False Then
                    contraid.Text = 578
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 578
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F102") Then
                If trato.Checked = False Then
                    contraid.Text = 579
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 579
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F103") Then
                If trato.Checked = False Then
                    'contraid.Text = 1103
                    contraid.Text = 678
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 1103
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F104") Then
                If trato.Checked = False Then
                    'contraid.Text = 1103
                    contraid.Text = 652
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 652
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F105") Then
                If trato.Checked = False Then
                    contraid.Text = 636
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 636
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F106") Then
                If trato.Checked = False Then
                    contraid.Text = 678
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 678
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F107") Then
                If trato.Checked = False Then
                    contraid.Text = 1153
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 1153
                    contraid.Text = ""
                End If
                ' Else
                '    id_contratista.Text = 0
                '   contraid.Text = 0
            End If
        ElseIf tipot.Text = "L" Then
            If (equivalencia.Text = "F201") Then
                If trato.Checked = False Then
                    contraid.Text = 678
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 678
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F203") Then
                If trato.Checked = False Then
                    'contraid.Text = 229
                    contraid.Text = 655
                    id_contratista.Text = ""
                Else
                    'id_contratista.Text = 229
                    id_contratista.Text = 655
                    contraid.Text = ""
                End If
            ElseIf (equivalencia.Text = "F202") Then
                If trato.Checked = False Then
                    contraid.Text = 678
                    id_contratista.Text = ""
                Else
                    id_contratista.Text = 678
                    contraid.Text = ""
                End If
                'Else
                '   id_contratista.Text = 0
                '  contraid.Text = 0
            End If
        End If
    End Sub

    Private Sub contraid_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contraid.LostFocus
        If (equivalencia.Text = "F101") Then
            If (contraid.Text <> 578) Then
                MsgBox("Contratista no Corresponde a la planilla")
            End If
        ElseIf (equivalencia.Text = "F102") Then
            If (contraid.Text <> 579) Then
                MsgBox("Contratista no Corresponde a la planilla")
            End If
        ElseIf (equivalencia.Text = "F104") Then
            If (contraid.Text <> 652) Then
                MsgBox("Contratista no Corresponde a la planilla")
            End If
        ElseIf (equivalencia.Text = "F105") Then
            If (contraid.Text <> 636) Then
                MsgBox("Contratista no Corresponde a la planilla")
            End If
        ElseIf (equivalencia.Text = "F106") Then
            If (contraid.Text <> 678) Then
                MsgBox("Contratista no Corresponde a la planilla")
            End If
        ElseIf (equivalencia.Text = "F107") Then
            If (contraid.Text <> 1153) Then
                MsgBox("Contratista no Corresponde a la planilla")
            End If
        Else
            contraid.Text = contraid.Text
        End If
    End Sub

    Private Sub Previa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Previa.Click
        try
            If (IMPRESIONPRE >= 1) Then
                Previa.Enabled = Enabled
            Else
                If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "T" Or tipot.Text = "M" Or tipot.Text = "L" Then
                    If detallet.TextLength > 0 Then
                        'f_previa()
                        f_imp_previa("0C61CF24B074")
                    Else
                        MsgBox("Debe ingresar al menos un registro")
                        racimo.Text = ""
                    End If
                Else
                    'f_previa()
                    f_imp_previa("0C61CF24B074")
                End If
            End If
        Catch f As Exception
            ' Handle communications error here.
            Console.Write(f.StackTrace)
        End Try
    End Sub
    Private Sub f_previa()
        numero_reporte()
        If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
            cuenta_unadas()
        ElseIf ((tipot.Text = "M") Or (tipot.Text = "L")) Then
            cuenta_carretas()
        End If
        v_previa = 1
        Generar.Enabled = True
        Generar.Visible = True
        'datos de impresion
        Dim RESPUESTA As MsgBoxResult = Nothing
        Dim contador_generar As Integer = 0
        Dim espera As Long = 0
        TOTAL_SACOS = 0
        fecha_env = Now.ToString("yyyyMMdd HH:mm")
        Generado.Text = ""
        detallegc = ""

        Try
            If Not position Is Nothing Then
                txtResult.Text = position.EnCerca(txtLon1.Text, txtLat1.Text, txtLon2.Text, txtLat2.Text, txtLon3.Text, txtLat3.Text, TxtLon4.Text, TxtLat4.Text).ToString
            End If
        Catch EX As Exception
            MsgBox("Error producido por gps " & EX.Message & vbCrLf, Nothing, "Error")
        End Try
        If tipot.Text <> "U" And tipot.Text <> "V" Then
            zona.Text = Lizona.Items.Item(Lizona.SelectedIndex)
            If txtLote.Text.Length < 0 Then
                lote1 = ""
            Else
                lote1 = txtLote.Text
            End If
            'If lilo1.SelectedIndex < 0 Then
            'lote1 = ""
            'Else
            '   lote1 = lilo1.Items.Item(lilo1.SelectedIndex).ToString()
            'End If
            If lilo2.SelectedIndex < 0 Then
                lote2 = ""
            Else
                lote2 = lilo2.Items.Item(lilo2.SelectedIndex).ToString()
            End If
            If lilo3.SelectedIndex < 0 Then
                lote3 = ""
            Else
                lote3 = lilo3.Items.Item(lilo3.SelectedIndex).ToString()
            End If
            If lilo4.SelectedIndex < 0 Then
                lote4 = ""
            Else
                lote4 = lilo4.Items.Item(lilo4.SelectedIndex).ToString()
            End If
            If lilo5.SelectedIndex < 0 Then
                lote5 = ""
            Else
                lote5 = lilo5.Items.Item(lilo5.SelectedIndex).ToString()
            End If
            If lilo6.SelectedIndex < 0 Then
                lote6 = ""
            Else
                lote6 = lilo6.Items.Item(lilo6.SelectedIndex).ToString()
            End If
            If txtPante.Text.Length < 0 Then
                pante1 = ""
            Else
                pante1 = txtPante.Text
            End If
            'If lipa1.SelectedIndex < 0 Then
            'pante1 = ""
            'Else
            '   pante1 = lipa1.Items.Item(lipa1.SelectedIndex).ToString()
            'End If
            If lipa2.SelectedIndex < 0 Then
                pante2 = ""
            Else
                pante2 = lipa2.Items.Item(lipa2.SelectedIndex).ToString()
            End If
            If lipa3.SelectedIndex < 0 Then
                pante3 = ""
            Else
                pante3 = lipa3.Items.Item(lipa3.SelectedIndex).ToString()
            End If
            If lipa4.SelectedIndex < 0 Then
                pante4 = ""
            Else
                pante4 = lipa4.Items.Item(lipa4.SelectedIndex).ToString()
            End If
            If lipa5.SelectedIndex < 0 Then
                pante5 = ""
            Else
                pante5 = lipa5.Items.Item(lipa5.SelectedIndex).ToString()
            End If
            If lipa6.SelectedIndex < 0 Then
                pante6 = ""
            Else
                pante6 = lipa6.Items.Item(lipa6.SelectedIndex).ToString()
            End If
        End If
        If presenta.Checked Then
            presentacion = "Q"
        Else
            presentacion = "C"
        End If

        If ((tipot.Text = "C") Or (tipot.Text = "G") Or (tipot.Text = "L")) Then 'ticket = boleta de transporte'
            If detallet.TextLength > 0 Then
                salto = Convert.ToInt32(detallet.TextLength / 35)
                While contador_generar < salto
                    Dim linea As String = ""
                    linea = detallet.Text.Substring(contador_generar * 35, 35) 'comparab = detalle.Text.Substring(CONTADOR * 35, 35)
                    detallegc = detallegc + Lpad(linea.Substring(0, 3), "0", 3) + Lpad(linea.Substring(3, 3), "0", 3) + Lpad(linea.Substring(6, 6), "0", 6) + Lpad(linea.Substring(12, 3), "0", 3) + Lpad(linea.Substring(15, 8), "0", 8) + Lpad(linea.Substring(23, 6), "0", 6).ToUpper + Lpad(linea.Substring(29, 6), "0", 6).ToUpper
                    contador_generar = contador_generar + 1
                End While
            End If
            ''--------------------
            'If trato.Checked = True Then
            '    Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
            'Else
            '    Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
            '    'Dim otro As Integer = Generado.TextLength
            '    'otro = otro
            'End If

        ElseIf (tipot.Text = "L") Then
            If flete = "P" Then
                texto = "PROPIO"
            Else
                texto = "FLETERO"
            End If
        End If
        If BTPRINT.IsOpen Then
            BTPRINT.Close()
        End If

        Try
            BTPRINT.Open()
            BTPRINT.WriteTimeout = 90000
            'BTPRINT.WriteTimeout = System.IO.Ports.SerialPort.InfiniteTimeout 'serial.InfiniteTimeout


            coordenada = 10
            nombre_empresa = ""
            NOMBRE_BOLETA = ""
            unidades.Text = ""
            ENC = ""
            If Empresa.Text = "1" Then
                nombre_empresa = "VISTA PREVIA"
            ElseIf Empresa.Text = "6326" Then
                nombre_empresa = "TIKINDUSTRIAS, S. A."
            Else
                If Empresa.Text = "6327" Then
                    nombre_empresa = "PALMA SUR, S. A."
                End If
            End If
            If tipot.Text = "L" And cole_mal.Text.Length >= "1" Then
                NOMBRE_BOLETA = "NOTA DE ENVIO DE CAÑA MALETEADA (COLERA)"
                unidades.Text = "MALETAS"
            ElseIf tipot.Text = "M" And cole_meca.Text.Length >= "1" Then
                NOMBRE_BOLETA = "NOTA DE ENVIO DE CAÑA MECANIZADA(COLERA)"
                unidades.Text = "CARRETAS"
            Else
                If tipot.Text = "C" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL (COLERA)"
                    unidades.Text = "UNADAS"
                ElseIf tipot.Text = "G" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL"
                    unidades.Text = "UNADAS"
                ElseIf tipot.Text = "M" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA COSECHA MECANIZADA"
                    unidades.Text = "CARRETAS"
                ElseIf tipot.Text = "L" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA MALETEADA"
                    unidades.Text = "MALETAS"
                ElseIf tipot.Text = "T" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA TRAMEADO"
                    unidades.Text = "MALETAS"
                ElseIf tipot.Text = "U" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A FABRICA"
                    unidades.Text = "CANASTAS"
                ElseIf tipot.Text = "V" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A VENTA"
                    unidades.Text = "RACIMOS"
                End If
            End If
            ENC = Chr(27) & "EZ" & "{PRINT:" & "@" & coordenada & ",250:MF107,VMULT2|" & nombre_empresa & "|"

            coordenada = coordenada + 70
            ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & NOMBRE_BOLETA & "|"
            If Empresa.Text = "6327" Then
                coordenada = coordenada + 70
                ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & serie_preparada & "|"
            ElseIf Empresa.Text = "6326" Then
                coordenada = coordenada + 70
                ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & serie_preparada & "|"
            Else
                coordenada = coordenada + 70
                ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                         SERIE: " & serie_preparada & "|"
            End If
            'coordenada = coordenada + 70
            ENC &= "@" & coordenada & ", 50:MF107, VMULT2|ENVIO NO.:   " & Lpad(NUMERO_REP, "0", 6) & "|"
            ENC &= "}" & "{AHEAD:12}" & "{LP}"
            BTPRINT.Write(ENC)
            coordenada = 10
            IMP = Chr(27) & "EZ" & "{PRINT:" & "@" & coordenada & ",50:MF204,VMULT1 |FECHA:       " & Now.ToString("dd/MM/yyyy HH:mm") & "|"
            coordenada = coordenada + 30
            IMP &= "@" & coordenada & ",50:MF204,VMULT1 |FINCA:       " & Lpad(Id_finca.Text, "0", 3) & "  " & Nombre_finca.Text & "|"
            coordenada = coordenada + 30
            If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CROQUIS:                 " + SerieCroquis.Text + "   " & Lpad(Croquis.Text, "0", 8) & "|" '"  " & nombre_trans & 
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ORDEN CORTE:             " & Lpad(ocorte.Text, "0", 8) & "|" '"  " & nombre_trans & 
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(trans.Text, "0", 4) & "|" '"  " & nombre_trans & 
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(pilo.Text, "0", 3) & "|" '"  " & nombre_pilo &
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "|" '"  " & placa_vehi & 
            Else
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(trans.Text, "0", 4) & "  " & nombre_trans & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(pilo.Text, "0", 3) & "  " & nombre_pilo & "|" '
                coordenada = coordenada + 30
                If (tipot.Text = "T" Or tipot.Text = "L") Then
                    If (p_placa.Length > 1) Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "      Placas:  " + p_placa + "|"
                    Else
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "      Placas:  " + txtPLaca.Text + "|"
                    End If
                Else
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "|"
                End If
                coordenada = coordenada + 30
                If ((tipot.Text = "T") Or (tipot.Text = "L")) Then
                    If (Manual.CheckState = Windows.Forms.CheckState.Checked) Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |Placa Manual |"
                    Else
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |STICKER |"
                    End If
                End If
            End If
                If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1 |FRENTE:                  " & Lpad(Id_Frente.Text, "0", 3) & "|"
                If (tipot.Text <> "T") Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |BOLETA DE TRANSPORTE:    " & Lpad(Nboleta.Text, "0", 6) & "|"
                End If
            Else
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204,VMULT1 |SECTOR:                  " & Lpad(Id_Frente.Text, "0", 3) & "|"
            End If
            If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |RUTA:                    " & Lpad(id_ruta.Text, "0", 3) & "|"
            End If
            If (tipot.Text <> "T") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PLATAFORMA:              " & Lpad(plata.Text, "0", 4) & "|"
            End If
            If ((tipot.Text = "C") Or (tipot.Text = "G") Or (tipot.Text = "M") Or (tipot.Text = "L")) Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |COLERA:                  " & Lpad(cole.Text, "0", 4) & "|"
            End If
            If ((tipot.Text <> "M") And (tipot.Text <> "T") And (tipot.Text <> "L")) Then
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(contraid.Text, "0", 4) & "|" ' "  " & nombre_contra &
                Else
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(contraid.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                End If
            End If
            If (tipot.Text = "T") Then
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "|" ' "  " & nombre_contra &
                Else
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                End If
            End If
            If (tipot.Text = "L") Then
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "|" ' "  " & nombre_contra &
                Else
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                End If
            End If
            coordenada = coordenada + 30
            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |HORA DE DESPACHO:        " & TimeOfDay.ToString("HH:mm") & "|"
            'If (tipo <> "U") Then
            coordenada = coordenada + 30
            If (tipot.Text <> "U") And (tipot.Text <> "T") And (tipot.Text <> "V") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TURNO:                   " & grupo.Text & "|"
            ElseIf tipot.Text = "T" Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CUADRILLA:               " & grupo.Text & "|"
            Else
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |GRUPO:                   " & grupo.Text & "|"
            End If
            If tipot.Text = "V" Or tipot.Text = "U" Then
                Dim DATO As DateTime = Now
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                Dim QUERY = New SqlCeCommand()
                Dim dr As SqlCeDataReader = Nothing

                QUERY = New SqlCeCommand("SELECT FECHA_SIEMBRA FROM TB_LOTES WHERE ID_FINCA =  " & Id_finca.Text & " AND ID_PANTE = " & Id_Frente.Text & " AND ID_LOTE = " & lipa1.Items.Item(lipa1.SelectedIndex) & " ;", CONN)
                Try
                    If CONN.State = Data.ConnectionState.Open Then
                        CONN.Close()
                    Else
                        CONN.Open()
                    End If
                    dr = QUERY.ExecuteReader()
                    While dr.Read()
                        DATO = Convert.ToDateTime(dr(0).ToString)
                    End While
                Catch ex As Exception
                    MsgBox("Error ocasionado por 21 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PERIODO SIEMBRA:        " & DATO.ToString("yyyy") & "|"
            End If
            If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ALZADOR:                 " & Lpad(ALZ.Text, "0", 3) & "     OPERADOR ALZADOR " & Lpad(OPA.Text, "0", 6) & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRACTOR:                 " & Lpad(TRA.Text, "0", 3) & "     OPERADOR TRACTOR " & Lpad(OPT.Text, "0", 6) & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FECHA TURNO:                 " & Lpad(fecturno.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecturno.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecturno.Text.Substring(4, 4), "0", 4) & "|"
            End If
            coordenada = coordenada + 30
            total_unidades = 0
            If unidad.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad.Text)
            End If
            If unidad2.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad2.Text)
            End If
            If unidad3.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad3.Text)
            End If
            If unidad4.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad4.Text)
            End If
            If unidad5.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad5.Text)
            End If
            If unidad6.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad6.Text)
            End If
            'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & UNIDADES & ":        " & total_unidades & "|"

            If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PRESENTACION:                 " & Lpad(presentacion, "0", 1) & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |     LOTE           FECH QUEMA      HORA QUEMA      " & unidades.Text & "|"
            Else
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |BLOQUE    VARIEDAD  FECH CORTE      HORA CORTE      " & unidades.Text & "|"
            End If
            fechaq1 = Lpad(fe_quema.Text, "0", 8)
            fechaq2 = Lpad(quema2.Text, "0", 8)
            fechaq3 = Lpad(quema3.Text, "0", 8)
            fechaq4 = Lpad(quema4.Text, "0", 8)
            fechaq5 = Lpad(quema5.Text, "0", 8)
            fechaq6 = Lpad(quema6.Text, "0", 8)
            horaq1 = Lpad(Ho_quema.Text, "0", 4)
            horaq2 = Lpad(hora2.Text, "0", 4)
            horaq3 = Lpad(hora3.Text, "0", 4)
            horaq4 = Lpad(hora4.Text, "0", 4)
            horaq5 = Lpad(hora5.Text, "0", 4)
            horaq6 = Lpad(hora6.Text, "0", 4)

            If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                SumaRacimo.Text = total_deta_u
                SumaCarreta.Text = total_deta_c
                coordenada = coordenada + 30
                If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(SumaRacimo.Text, "0", 3) & "|"
                ElseIf (tipot.Text = "M") Then
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(SumaCarreta.Text, "0", 3) & "|"
                ElseIf (tipot.Text = "L") Then
                    'IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(cortadores.Text, "0", 3) & "|"
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                Else
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                End If
                If lote2.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante2, "0", 3) & "       " & Lpad(lote2, "0", 3) & "       " & fechaq2.Substring(0, 2) & "/" & fechaq2.Substring(2, 2) & "/" & fechaq2.Substring(4, 4) & "        " & horaq2.Substring(0, 2) & ":" & horaq2.Substring(2, 2) & "         " & Lpad(unidad2.Text, "0", 3) & "|"
                End If
                If lote3.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante3, "0", 3) & "       " & Lpad(lote3, "0", 3) & "       " & fechaq3.Substring(0, 2) & "/" & fechaq3.Substring(2, 2) & "/" & fechaq3.Substring(4, 4) & "        " & horaq3.Substring(0, 2) & ":" & horaq3.Substring(2, 2) & "         " & Lpad(unidad3.Text, "0", 3) & "|"
                End If
                If lote4.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante4, "0", 3) & "       " & Lpad(lote4, "0", 3) & "       " & fechaq4.Substring(0, 2) & "/" & fechaq4.Substring(2, 2) & "/" & fechaq4.Substring(4, 4) & "        " & horaq4.Substring(0, 2) & ":" & horaq4.Substring(2, 2) & "         " & Lpad(unidad4.Text, "0", 3) & "|"
                End If
                If lote5.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante5, "0", 3) & "       " & Lpad(lote5, "0", 3) & "       " & fechaq5.Substring(0, 2) & "/" & fechaq5.Substring(2, 2) & "/" & fechaq5.Substring(4, 4) & "        " & horaq5.Substring(0, 2) & ":" & horaq5.Substring(2, 2) & "         " & Lpad(unidad5.Text, "0", 3) & "|"
                End If
                If lote6.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante6, "0", 3) & "       " & Lpad(lote6, "0", 3) & "       " & fechaq6.Substring(0, 2) & "/" & fechaq6.Substring(2, 2) & "/" & fechaq6.Substring(4, 4) & "        " & horaq6.Substring(0, 2) & ":" & horaq6.Substring(2, 2) & "         " & Lpad(unidad6.Text, "0", 3) & "|"
                End If
            Else
                Dim CONN2 = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                Dim QUERY2 = New SqlCeCommand()
                Dim dr As SqlCeDataReader = Nothing

                QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote1 & " ;", CONN2)
                Try
                    If CONN2.State = Data.ConnectionState.Open Then
                        CONN2.Close()
                    Else
                        CONN2.Open()
                    End If
                    dr = QUERY2.ExecuteReader()
                    While dr.Read()
                        VARIEDAD_DESC = dr(0).ToString
                    End While
                Catch ex As Exception
                    MsgBox("Error ocasionado por 22 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                If lote2.Length > 0 Then
                    QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN2)
                    Try
                        If CONN2.State = Data.ConnectionState.Open Then
                            CONN2.Close()
                        Else
                            CONN2.Open()
                        End If
                        dr = QUERY2.ExecuteReader()
                        While dr.Read()
                            VARIEDAD_DESC = dr(0).ToString
                        End While
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 23 " & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante2, "0", 3) & "       " & Lpad(lote2, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq2.Substring(0, 2) & "/" & fechaq2.Substring(2, 2) & "/" & fechaq2.Substring(4, 4) & "        " & horaq2.Substring(0, 2) & ":" & horaq2.Substring(2, 2) & "         " & Lpad(unidad2.Text, "0", 3) & "|"

                End If
                If lote3.Length > 0 Then
                    QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN2)
                    Try
                        If CONN2.State = Data.ConnectionState.Open Then
                            CONN2.Close()
                        Else
                            CONN2.Open()
                        End If
                        dr = QUERY2.ExecuteReader()
                        While dr.Read()
                            VARIEDAD_DESC = dr(0).ToString
                        End While
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 24 " & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante3, "0", 3) & "       " & Lpad(lote3, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq3.Substring(0, 2) & "/" & fechaq3.Substring(2, 2) & "/" & fechaq3.Substring(4, 4) & "        " & horaq3.Substring(0, 2) & ":" & horaq3.Substring(2, 2) & "         " & Lpad(unidad3.Text, "0", 3) & "|"
                End If
                If lote4.Length > 0 Then
                    QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN2)
                    Try
                        If CONN2.State = Data.ConnectionState.Open Then
                            CONN2.Close()
                        Else
                            CONN2.Open()
                        End If
                        dr = QUERY2.ExecuteReader()
                        While dr.Read()
                            VARIEDAD_DESC = dr(0).ToString
                        End While
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 25 " & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante4, "0", 3) & "       " & Lpad(lote4, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq4.Substring(0, 2) & "/" & fechaq4.Substring(2, 2) & "/" & fechaq4.Substring(4, 4) & "        " & horaq4.Substring(0, 2) & ":" & horaq4.Substring(2, 2) & "         " & Lpad(unidad4.Text, "0", 3) & "|"
                End If
            End If
            coordenada = coordenada + 30
            If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR            UNADAS      FECHA CORTE      EQUIVALENCIA|"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 35)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "    " & linea.Substring(3, 3) & "        " & linea.Substring(6, 6) & "  " & linea.Substring(29, 6) & "         " & linea.Substring(12, 3) & "      " & linea.Substring(15, 2) & "/" & linea.Substring(17, 2) & "/" & linea.Substring(19, 4) & "       " & linea.Substring(23, 6) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(12, 3))
                    If ((salto = 25) Or (salto = 50)) Then
                        IMP &= "}" & "{AHEAD:0}" & "{LP}"
                        BTPRINT.Write(IMP)
                        IMP = Chr(27) & "EZ" & "{PRINT: "
                        coordenada = 0
                    End If
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1

                End While
                ''temporal erick''
                'If trato.Checked = True Then
                '    coordenada = coordenada + 30
                '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                                  " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "             |"
                'End If
                ''
            ElseIf (tipot.Text = "L") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR            QUINTALES      FECHA CORTE      EQUIVALENCIA|"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 35)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "    " & linea.Substring(3, 3) & "        " & linea.Substring(6, 6) & "  " & linea.Substring(29, 6) & "         " & linea.Substring(12, 3) & "      " & linea.Substring(15, 2) & "/" & linea.Substring(17, 2) & "/" & linea.Substring(19, 4) & "       " & linea.Substring(23, 6) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(12, 3))
                    If ((salto = 25) Or (salto = 50)) Then
                        IMP &= "}" & "{AHEAD:0}" & "{LP}"
                        BTPRINT.Write(IMP)
                        IMP = Chr(27) & "EZ" & "{PRINT: "
                        coordenada = 0
                    End If
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1

                End While
                ''temporal erick''
                'If trato.Checked = True Then
                '    coordenada = coordenada + 30
                '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                                  " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "             |"
                'End If
                ''
            ElseIf ((tipot.Text = "T") Or (tipot.Text = "T")) Then
                If tipot.Text = "T" Then
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      EQUIVALENCIA      FECHA CORTE|"
                    'MsgBox(detalle.Text.Length / 12)
                    corte = (detallet.Text.Length / 20)
                    salto = 1
                    LecturaF.Text = 0
                    'MsgBox(corte)
                    While salto <= corte
                        linea = ""
                        coordenada = coordenada + 30
                        linea = detallet.Text.Substring(LecturaF.Text * 20, 20)
                        'MsgBox("linea: " & linea)
                        'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "        " & linea.Substring(6, 6) & "            " & linea.Substring(12, 2) & "/" & linea.Substring(14, 2) & "/" & linea.Substring(16, 4) & "|"
                        salto = salto + 1
                        LecturaF.Text = LecturaF.Text + 1
                    End While
                    ''temporal erick''
                    'If trato.Checked = True Then
                    '    coordenada = coordenada + 30
                    '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "|"
                    'End If
                    ''
                End If
                total_detalle = total_unidades
            ElseIf (tipot.Text = "M") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADORA      TRACTOR      CARRETAS      O. CORTADORA      O. TRACTOR|"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 21)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 21, 21)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "            " & linea.Substring(3, 3) & "           " & linea.Substring(6, 3) & "           " & linea.Substring(9, 6) & "           " & linea.Substring(15, 6) & "|"
                    ' total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                total_detalle = total_unidades
            ElseIf (tipot.Text = "U") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      CANASTAS |"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 9)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 9, 9)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "            " & linea.Substring(6, 3) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
            ElseIf (tipot.Text = "V") Then
                'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      CANASTAS |"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 12)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    'coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 12, 12)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "            " & linea.Substring(6, 3) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    TOTAL_SACOS = TOTAL_SACOS + Convert.ToInt32(linea.Substring(9, 3))
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
            End If
            If tipot.Text = "M" Then
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & cortadores.Text & " |"
            ElseIf tipot.Text = "L" Then
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & unidad.Text & " |"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL QUINTALES:  " & total_detalle & " |"
                coordenada = coordenada + 30
                total_tonelada = total_detalle / 20
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL TONELADAS:  " & total_tonelada & " |"
            Else
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & total_detalle & " |"
            End If
            If tipot.Text = "V" Then
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL SACOS: " & TOTAL_SACOS & " |"
            End If
            coordenada = coordenada + 30
            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ENVIERO:      " & Lpad(usuario.Text, "0", 6) & " |"
            If (tipot.Text = "L") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TIPO:     " & texto & " |"
            End If
            If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "T" Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | TOTAL DE CORTADORES INGRESADOS : " & cortadores.Text & "|"
            End If
            If tipot.Text = "M" Then
                Dim TOTAL_CARRETAS As Integer = 0
                TOTAL_CARRETAS = Convert.ToInt32(cortadores.Text.Trim)
            End If
            coordenada = coordenada + 50
            IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | IMPRESION NUMERO : ** PREVIA ** |"
            coordenada = coordenada + 50
            IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | UBICACION : " & txtLatitud.Text & ", " & txtLongitud.Text & ", " & txtResult.Text & "|"
            coordenada = coordenada + 50

            IMP &= "}" & "{AHEAD:125}" & "{LP}"
            BTPRINT.Write(IMP)
            BTPRINT.Close()
        Catch ex As Exception
            MsgBox("Error ocacionado por 18" & ex.Message & vbCrLf & "Favor de Reportarlo.")
        End Try
        IMPRESIONPRE = IMPRESIONPRE + 1
    End Sub

    Private Sub f_imp_previa(ByVal theBtMacAddress As [String])
        numero_reporte()
        If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
            cuenta_unadas()
        ElseIf ((tipot.Text = "M") Or (tipot.Text = "L")) Then
            cuenta_carretas()
        End If
        v_previa = 1
        Generar.Enabled = True
        Generar.Visible = True
        'datos de impresion
        Dim RESPUESTA As MsgBoxResult = Nothing
        Dim contador_generar As Integer = 0
        Dim espera As Long = 0
        TOTAL_SACOS = 0
        fecha_env = Now.ToString("yyyyMMdd HH:mm")
        Generado.Text = ""
        detallegc = ""

        Try
            If Not position Is Nothing Then
                txtResult.Text = position.EnCerca(txtLon1.Text, txtLat1.Text, txtLon2.Text, txtLat2.Text, txtLon3.Text, txtLat3.Text, TxtLon4.Text, TxtLat4.Text).ToString
            End If
        Catch EX As Exception
            MsgBox("Error producido por gps " & EX.Message & vbCrLf, Nothing, "Error")
        End Try
        If tipot.Text <> "U" And tipot.Text <> "V" Then
            zona.Text = Lizona.Items.Item(Lizona.SelectedIndex)
            If txtLote.Text.Length < 0 Then
                lote1 = ""
            Else
                lote1 = txtLote.Text
            End If
            'If lilo1.SelectedIndex < 0 Then
            'lote1 = ""
            'Else
            '   lote1 = lilo1.Items.Item(lilo1.SelectedIndex).ToString()
            'End If
            If lilo2.SelectedIndex < 0 Then
                lote2 = ""
            Else
                lote2 = lilo2.Items.Item(lilo2.SelectedIndex).ToString()
            End If
            If lilo3.SelectedIndex < 0 Then
                lote3 = ""
            Else
                lote3 = lilo3.Items.Item(lilo3.SelectedIndex).ToString()
            End If
            If lilo4.SelectedIndex < 0 Then
                lote4 = ""
            Else
                lote4 = lilo4.Items.Item(lilo4.SelectedIndex).ToString()
            End If
            If lilo5.SelectedIndex < 0 Then
                lote5 = ""
            Else
                lote5 = lilo5.Items.Item(lilo5.SelectedIndex).ToString()
            End If
            If lilo6.SelectedIndex < 0 Then
                lote6 = ""
            Else
                lote6 = lilo6.Items.Item(lilo6.SelectedIndex).ToString()
            End If
            If txtPante.Text.Length < 0 Then
                pante1 = ""
            Else
                pante1 = txtPante.Text
            End If
            'If lipa1.SelectedIndex < 0 Then
            'pante1 = ""
            'Else
            '   pante1 = lipa1.Items.Item(lipa1.SelectedIndex).ToString()
            'End If
            If lipa2.SelectedIndex < 0 Then
                pante2 = ""
            Else
                pante2 = lipa2.Items.Item(lipa2.SelectedIndex).ToString()
            End If
            If lipa3.SelectedIndex < 0 Then
                pante3 = ""
            Else
                pante3 = lipa3.Items.Item(lipa3.SelectedIndex).ToString()
            End If
            If lipa4.SelectedIndex < 0 Then
                pante4 = ""
            Else
                pante4 = lipa4.Items.Item(lipa4.SelectedIndex).ToString()
            End If
            If lipa5.SelectedIndex < 0 Then
                pante5 = ""
            Else
                pante5 = lipa5.Items.Item(lipa5.SelectedIndex).ToString()
            End If
            If lipa6.SelectedIndex < 0 Then
                pante6 = ""
            Else
                pante6 = lipa6.Items.Item(lipa6.SelectedIndex).ToString()
            End If
        End If
        If presenta.Checked Then
            presentacion = "Q"
        Else
            presentacion = "C"
        End If

        If ((tipot.Text = "C") Or (tipot.Text = "G") Or (tipot.Text = "L")) Then 'ticket = boleta de transporte'
            If detallet.TextLength > 0 Then
                salto = Convert.ToInt32(detallet.TextLength / 35)
                While contador_generar < salto
                    Dim linea As String = ""
                    linea = detallet.Text.Substring(contador_generar * 35, 35) 'comparab = detalle.Text.Substring(CONTADOR * 35, 35)
                    detallegc = detallegc + Lpad(linea.Substring(0, 3), "0", 3) + Lpad(linea.Substring(3, 3), "0", 3) + Lpad(linea.Substring(6, 6), "0", 6) + Lpad(linea.Substring(12, 3), "0", 3) + Lpad(linea.Substring(15, 8), "0", 8) + Lpad(linea.Substring(23, 6), "0", 6).ToUpper + Lpad(linea.Substring(29, 6), "0", 6).ToUpper
                    contador_generar = contador_generar + 1
                End While
            End If
            ''--------------------
            'If trato.Checked = True Then
            '    Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
            'Else
            '    Generado.Text = Replace(Lpad(txtLatitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtLongitud.Text, "0", 12), Chr(39), "!") + Replace(Lpad(txtResult.Text.Substring(0, 1), "0", 2), Chr(39), "!") + Lpad(Empresa.Text, "0", 4) + Lpad(serie_preparada, "0", 4) + Lpad(NUMERO_REP, "0", 6) + Now.ToString("ddMMyyyyHHmm") + Lpad(Id_finca.Text, "0", 4) + Lpad(Id_Frente.Text, "0", 4) + Lpad(trans.Text, "0", 4) + Lpad(vehi.Text, "0", 3) + Lpad(pilo.Text, "0", 3) + Lpad(plata.Text, "0", 3) + Lpad(contraid.Text, "0", 4) + Lpad(ENV.Text, "0", 6) + Lpad(lote1, "0", 3) + Lpad(lote2, "0", 3) + Lpad(lote3, "0", 3) + Lpad(lote4, "0", 3) + Lpad(lote5, "0", 3) + Lpad(lote6, "0", 3) + Lpad(pante1, "0", 3) + Lpad(pante2, "0", 3) + Lpad(pante3, "0", 3) + Lpad(pante4, "0", 3) + Lpad(pante5, "0", 3) + Lpad(pante6, "0", 3) + Lpad(unidad.Text, "0", 3) + Lpad(unidad2.Text, "0", 3) + Lpad(unidad3.Text, "0", 3) + Lpad(unidad4.Text, "0", 3) + Lpad(unidad5.Text, "0", 3) + Lpad(unidad6.Text, "0", 3) + Lpad(fe_quema.Text, "0", 8) + Lpad(quema2.Text, "0", 8) + Lpad(quema3.Text, "0", 8) + Lpad(quema4.Text, "0", 8) + Lpad(quema5.Text, "0", 8) + Lpad(quema6.Text, "0", 8) + Lpad(Ho_quema.Text, "0", 4) + Lpad(hora2.Text, "0", 4) + Lpad(hora3.Text, "0", 4) + Lpad(hora4.Text, "0", 4) + Lpad(hora5.Text, "0", 4) + Lpad(hora6.Text, "0", 4) + Lpad(Now.ToString("HHmm"), "0", 4) + Lpad(grupo.Text, "0", 3).ToUpper + Lpad(Id_ticket.Text, "0", 6) + Lpad(zona.Text, "0", 2) + Lpad(cole.Text, "0", 3) + Lpad(ALZ.Text, "0", 6) + Lpad(TRA.Text, "0", 6) + Lpad(OPA.Text, "0", 6) + Lpad(OPT.Text, "0", 6) + Lpad(ruta.Text, "0", 3) + Lpad(fecturno.Text, "0", 12) + Lpad(presentacion, "0", 2) + Lpad(fecha_corte.Text, "0", 8) + Lpad(ocorte.Text, "0", 8) + Lpad(Croquis.Text, "0", 8) + detallegc
            '    'Dim otro As Integer = Generado.TextLength
            '    'otro = otro
            'End If

        ElseIf (tipot.Text = "L") Then
            If flete = "P" Then
                texto = "PROPIO"
            Else
                texto = "FLETERO"
            End If
        End If
        If BTPRINT.IsOpen Then
            BTPRINT.Close()
        End If

        Try
            'BTPRINT.Open() jclaudio coment
            'BTPRINT.WriteTimeout = 90000 jclaudio coment
            'BTPRINT.WriteTimeout = System.IO.Ports.SerialPort.InfiniteTimeout 'serial.InfiniteTimeout
            Dim thePrinterConn As ZebraPrinterConnection = New BluetoothPrinterConnection(theBtMacAddress)
            thePrinterConn.Open()

            coordenada = 10
            nombre_empresa = ""
            NOMBRE_BOLETA = ""
            unidades.Text = ""
            ENC = ""
            If Empresa.Text = "1" Then
                nombre_empresa = "VISTA PREVIA"
            ElseIf Empresa.Text = "6326" Then
                nombre_empresa = "TIKINDUSTRIAS, S. A."
            Else
                If Empresa.Text = "6327" Then
                    nombre_empresa = "PALMA SUR, S. A."
                End If
            End If
            If tipot.Text = "L" And cole_mal.Text.Length >= "1" Then
                NOMBRE_BOLETA = "NOTA DE ENVIO DE CAÑA MALETEADA (COLERA)"
                unidades.Text = "MALETAS"
            ElseIf tipot.Text = "M" And cole_meca.Text.Length >= "1" Then
                NOMBRE_BOLETA = "NOTA DE ENVIO DE CAÑA MECANIZADA(COLERA)"
                unidades.Text = "CARRETAS"
            Else
                If tipot.Text = "C" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL (COLERA)"
                    unidades.Text = "UNADAS"
                ElseIf tipot.Text = "G" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA A GRANEL"
                    unidades.Text = "UNADAS"
                ElseIf tipot.Text = "M" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA COSECHA MECANIZADA"
                    unidades.Text = "CARRETAS"
                ElseIf tipot.Text = "L" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA MALETEADA"
                    unidades.Text = "MALETAS"
                ElseIf tipot.Text = "T" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE CANA TRAMEADO"
                    unidades.Text = "MALETAS"
                ElseIf tipot.Text = "U" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A FABRICA"
                    unidades.Text = "CANASTAS"
                ElseIf tipot.Text = "V" Then
                    NOMBRE_BOLETA = "NOTA DE ENVIO DE PALMA AFRICANA A VENTA"
                    unidades.Text = "RACIMOS"
                End If
            End If

            'ENC = Chr(27) & "EZ" & "{PRINT:" & "@" & coordenada & ",250:MF107,VMULT2|" & nombre_empresa & "|"
            'coordenada = coordenada + 70
            'ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & NOMBRE_BOLETA & "|"
            If Empresa.Text = "6327" Then
                'coordenada = coordenada + 70
                ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & serie_preparada & "|"

            ElseIf Empresa.Text = "6326" Then
                coordenada = coordenada + 70
                ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                              SERIE: " & serie_preparada & "|"
            Else
                coordenada = coordenada + 70
                ENC &= "@" & coordenada & ", 50:MF107, VMULT2|" & "                         SERIE: " & serie_preparada & "|"
            End If
            'coordenada = coordenada + 70
            'ENC &= "@" & coordenada & ", 50:MF107, VMULT2|ENVIO NO.:   " & Lpad(NUMERO_REP, "0", 6) & "|"
            'ENC &= "}" & "{AHEAD:12}" & "{LP}"
            'BTPRINT.Write(ENC)
            Dim v_envio_no = Lpad(NUMERO_REP, "0", 6)

            coordenada = 10
            'IMP = Chr(27) & "EZ" & "{PRINT:" & "@" & coordenada & ",50:MF204,VMULT1 |FECHA:       " & Now.ToString("dd/MM/yyyy HH:mm") & "|"



            Dim encabezado As Byte() = Encoding.[Default].GetBytes("! 0 200 200 600 1" & vbCrLf & "PAGE-WIDTH 600" & vbCrLf & "CENTER" & vbCrLf & "T 4 0 1 10" & nombre_empresa & vbCrLf & "T 5 0 1 55" & NOMBRE_BOLETA & vbCrLf & "LEFT" & vbCrLf & "T 5 0 1 100 ENVIO: " & v_envio_no & vbCrLf & "T 5 0 300 100 SERIE: " & serie_preparada & vbCrLf & "T 5 0 1 130 FECHA: " & vbCrLf & "T 5 0 300 130" & Now.ToString("dd/MM/yyyy HH:mm") & vbCrLf & "T 5 0 1 160 FINCA: " & Lpad(Id_finca.Text, "0", 3) & Nombre_finca.Text & vbCrLf & "PRINT" & vbCrLf)


            thePrinterConn.Write(encabezado, 0, encabezado.Length)

            'coordenada = coordenada + 30
            ' IMP &= "@" & coordenada & ",50:MF204,VMULT1 |FINCA:       " & Lpad(Id_finca.Text, "0", 3) & "  " & Nombre_finca.Text & "|"
            ' coordenada = coordenada + 30


            If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CROQUIS:                 " + SerieCroquis.Text + "   " & Lpad(Croquis.Text, "0", 8) & "|" '"  " & nombre_trans & 
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ORDEN CORTE:             " & Lpad(ocorte.Text, "0", 8) & "|" '"  " & nombre_trans & 
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(trans.Text, "0", 4) & "|" '"  " & nombre_trans & 
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(pilo.Text, "0", 3) & "|" '"  " & nombre_pilo &
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "|" '"  " & placa_vehi & 
            Else
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRANSPORTISTA:           " & Lpad(trans.Text, "0", 4) & "  " & nombre_trans & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PILOTO:                  " & Lpad(pilo.Text, "0", 3) & "  " & nombre_pilo & "|" '
                coordenada = coordenada + 30
                If (tipot.Text = "T" Or tipot.Text = "L") Then
                    If (p_placa.Length > 1) Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "      Placas:  " + p_placa + "|"
                    Else
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "      Placas:  " + txtPLaca.Text + "|"
                    End If
                Else
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |VEHICULO:                " & Lpad(vehi.Text, "0", 3) & "|"
                End If
                coordenada = coordenada + 30
                If ((tipot.Text = "T") Or (tipot.Text = "L")) Then
                    If (Manual.CheckState = Windows.Forms.CheckState.Checked) Then
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |Placa Manual |"
                    Else
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |STICKER |"
                    End If
                End If
            End If
            If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204,VMULT1 |FRENTE:                  " & Lpad(Id_Frente.Text, "0", 3) & "|"
                If (tipot.Text <> "T") Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |BOLETA DE TRANSPORTE:    " & Lpad(Nboleta.Text, "0", 6) & "|"
                End If
            Else
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204,VMULT1 |SECTOR:                  " & Lpad(Id_Frente.Text, "0", 3) & "|"
            End If
            If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |RUTA:                    " & Lpad(id_ruta.Text, "0", 3) & "|"
            End If
            If (tipot.Text <> "T") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PLATAFORMA:              " & Lpad(plata.Text, "0", 4) & "|"
            End If
            If ((tipot.Text = "C") Or (tipot.Text = "G") Or (tipot.Text = "M") Or (tipot.Text = "L")) Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |COLERA:                  " & Lpad(cole.Text, "0", 4) & "|"
            End If
            If ((tipot.Text <> "M") And (tipot.Text <> "T") And (tipot.Text <> "L")) Then
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(contraid.Text, "0", 4) & "|" ' "  " & nombre_contra &
                Else
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(contraid.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                End If
            End If
            If (tipot.Text = "T") Then
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "|" ' "  " & nombre_contra &
                Else
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                End If
            End If
            If (tipot.Text = "L") Then
                If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "|" ' "  " & nombre_contra &
                Else
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CONTRATISTA:             " & Lpad(id_contratista.Text, "0", 4) & "  " & Contratista.Text & "|" ' 
                End If
            End If
            coordenada = coordenada + 30
            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |HORA DE DESPACHO:        " & TimeOfDay.ToString("HH:mm") & "|"
            'If (tipo <> "U") Then
            coordenada = coordenada + 30
            If (tipot.Text <> "U") And (tipot.Text <> "T") And (tipot.Text <> "V") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TURNO:                   " & grupo.Text & "|"
            ElseIf tipot.Text = "T" Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CUADRILLA:               " & grupo.Text & "|"
            Else
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |GRUPO:                   " & grupo.Text & "|"
            End If
            If tipot.Text = "V" Or tipot.Text = "U" Then
                Dim DATO As DateTime = Now
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                Dim QUERY = New SqlCeCommand()
                Dim dr As SqlCeDataReader = Nothing

                QUERY = New SqlCeCommand("SELECT FECHA_SIEMBRA FROM TB_LOTES WHERE ID_FINCA =  " & Id_finca.Text & " AND ID_PANTE = " & Id_Frente.Text & " AND ID_LOTE = " & lipa1.Items.Item(lipa1.SelectedIndex) & " ;", CONN)
                Try
                    If CONN.State = Data.ConnectionState.Open Then
                        CONN.Close()
                    Else
                        CONN.Open()
                    End If
                    dr = QUERY.ExecuteReader()
                    While dr.Read()
                        DATO = Convert.ToDateTime(dr(0).ToString)
                    End While
                Catch ex As Exception
                    MsgBox("Error ocasionado por 21 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PERIODO SIEMBRA:        " & DATO.ToString("yyyy") & "|"
            End If
            If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ALZADOR:                 " & Lpad(ALZ.Text, "0", 3) & "     OPERADOR ALZADOR " & Lpad(OPA.Text, "0", 6) & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TRACTOR:                 " & Lpad(TRA.Text, "0", 3) & "     OPERADOR TRACTOR " & Lpad(OPT.Text, "0", 6) & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FECHA TURNO:                 " & Lpad(fecturno.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecturno.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecturno.Text.Substring(4, 4), "0", 4) & "|"
            End If
            coordenada = coordenada + 30
            total_unidades = 0
            If unidad.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad.Text)
            End If
            If unidad2.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad2.Text)
            End If
            If unidad3.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad3.Text)
            End If
            If unidad4.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad4.Text)
            End If
            If unidad5.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad5.Text)
            End If
            If unidad6.Text = "" Then
                total_unidades = total_unidades + 0
            Else
                total_unidades = total_unidades + Convert.ToInt32(unidad6.Text)
            End If
            'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & UNIDADES & ":        " & total_unidades & "|"

            If (tipot.Text <> "U") And (tipot.Text <> "V") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |PRESENTACION:                 " & Lpad(presentacion, "0", 1) & "|"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |     LOTE           FECH QUEMA      HORA QUEMA      " & unidades.Text & "|"
            Else
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |BLOQUE    VARIEDAD  FECH CORTE      HORA CORTE      " & unidades.Text & "|"
            End If
            fechaq1 = Lpad(fe_quema.Text, "0", 8)
            fechaq2 = Lpad(quema2.Text, "0", 8)
            fechaq3 = Lpad(quema3.Text, "0", 8)
            fechaq4 = Lpad(quema4.Text, "0", 8)
            fechaq5 = Lpad(quema5.Text, "0", 8)
            fechaq6 = Lpad(quema6.Text, "0", 8)
            horaq1 = Lpad(Ho_quema.Text, "0", 4)
            horaq2 = Lpad(hora2.Text, "0", 4)
            horaq3 = Lpad(hora3.Text, "0", 4)
            horaq4 = Lpad(hora4.Text, "0", 4)
            horaq5 = Lpad(hora5.Text, "0", 4)
            horaq6 = Lpad(hora6.Text, "0", 4)

            If ((tipot.Text <> "U") And (tipot.Text <> "V")) Then
                SumaRacimo.Text = total_deta_u
                SumaCarreta.Text = total_deta_c
                coordenada = coordenada + 30
                If ((tipot.Text = "G") Or (tipot.Text = "C")) Then
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(SumaRacimo.Text, "0", 3) & "|"
                ElseIf (tipot.Text = "M") Then
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(SumaCarreta.Text, "0", 3) & "|"
                ElseIf (tipot.Text = "L") Then
                    'IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(cortadores.Text, "0", 3) & "|"
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                Else
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & "       " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                End If
                If lote2.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante2, "0", 3) & "       " & Lpad(lote2, "0", 3) & "       " & fechaq2.Substring(0, 2) & "/" & fechaq2.Substring(2, 2) & "/" & fechaq2.Substring(4, 4) & "        " & horaq2.Substring(0, 2) & ":" & horaq2.Substring(2, 2) & "         " & Lpad(unidad2.Text, "0", 3) & "|"
                End If
                If lote3.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante3, "0", 3) & "       " & Lpad(lote3, "0", 3) & "       " & fechaq3.Substring(0, 2) & "/" & fechaq3.Substring(2, 2) & "/" & fechaq3.Substring(4, 4) & "        " & horaq3.Substring(0, 2) & ":" & horaq3.Substring(2, 2) & "         " & Lpad(unidad3.Text, "0", 3) & "|"
                End If
                If lote4.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante4, "0", 3) & "       " & Lpad(lote4, "0", 3) & "       " & fechaq4.Substring(0, 2) & "/" & fechaq4.Substring(2, 2) & "/" & fechaq4.Substring(4, 4) & "        " & horaq4.Substring(0, 2) & ":" & horaq4.Substring(2, 2) & "         " & Lpad(unidad4.Text, "0", 3) & "|"
                End If
                If lote5.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante5, "0", 3) & "       " & Lpad(lote5, "0", 3) & "       " & fechaq5.Substring(0, 2) & "/" & fechaq5.Substring(2, 2) & "/" & fechaq5.Substring(4, 4) & "        " & horaq5.Substring(0, 2) & ":" & horaq5.Substring(2, 2) & "         " & Lpad(unidad5.Text, "0", 3) & "|"
                End If
                If lote6.Length > 0 Then
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante6, "0", 3) & "       " & Lpad(lote6, "0", 3) & "       " & fechaq6.Substring(0, 2) & "/" & fechaq6.Substring(2, 2) & "/" & fechaq6.Substring(4, 4) & "        " & horaq6.Substring(0, 2) & ":" & horaq6.Substring(2, 2) & "         " & Lpad(unidad6.Text, "0", 3) & "|"
                End If
            Else
                Dim CONN2 = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
                Dim QUERY2 = New SqlCeCommand()
                Dim dr As SqlCeDataReader = Nothing

                QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote1 & " ;", CONN2)
                Try
                    If CONN2.State = Data.ConnectionState.Open Then
                        CONN2.Close()
                    Else
                        CONN2.Open()
                    End If
                    dr = QUERY2.ExecuteReader()
                    While dr.Read()
                        VARIEDAD_DESC = dr(0).ToString
                    End While
                Catch ex As Exception
                    MsgBox("Error ocasionado por 22 " & ex.Message & vbCrLf & _
                                "Favor de reportarlo.")
                End Try
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante1, "0", 3) & "       " & Lpad(lote1, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq1.Substring(0, 2) & "/" & fechaq1.Substring(2, 2) & "/" & fechaq1.Substring(4, 4) & "        " & horaq1.Substring(0, 2) & ":" & horaq1.Substring(2, 2) & "         " & Lpad(unidad.Text, "0", 3) & "|"
                If lote2.Length > 0 Then
                    QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN2)
                    Try
                        If CONN2.State = Data.ConnectionState.Open Then
                            CONN2.Close()
                        Else
                            CONN2.Open()
                        End If
                        dr = QUERY2.ExecuteReader()
                        While dr.Read()
                            VARIEDAD_DESC = dr(0).ToString
                        End While
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 23 " & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante2, "0", 3) & "       " & Lpad(lote2, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq2.Substring(0, 2) & "/" & fechaq2.Substring(2, 2) & "/" & fechaq2.Substring(4, 4) & "        " & horaq2.Substring(0, 2) & ":" & horaq2.Substring(2, 2) & "         " & Lpad(unidad2.Text, "0", 3) & "|"

                End If
                If lote3.Length > 0 Then
                    QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN2)
                    Try
                        If CONN2.State = Data.ConnectionState.Open Then
                            CONN2.Close()
                        Else
                            CONN2.Open()
                        End If
                        dr = QUERY2.ExecuteReader()
                        While dr.Read()
                            VARIEDAD_DESC = dr(0).ToString
                        End While
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 24 " & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante3, "0", 3) & "       " & Lpad(lote3, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq3.Substring(0, 2) & "/" & fechaq3.Substring(2, 2) & "/" & fechaq3.Substring(4, 4) & "        " & horaq3.Substring(0, 2) & ":" & horaq3.Substring(2, 2) & "         " & Lpad(unidad3.Text, "0", 3) & "|"
                End If
                If lote4.Length > 0 Then
                    QUERY2 = New SqlCeCommand("SELECT DESCRIPCION FROM TB_VARIEDADES WHERE ID_VARIEDAD =  " & lote2 & " ;", CONN2)
                    Try
                        If CONN2.State = Data.ConnectionState.Open Then
                            CONN2.Close()
                        Else
                            CONN2.Open()
                        End If
                        dr = QUERY2.ExecuteReader()
                        While dr.Read()
                            VARIEDAD_DESC = dr(0).ToString
                        End While
                    Catch ex As Exception
                        MsgBox("Error ocasionado por 25 " & ex.Message & vbCrLf & _
                                    "Favor de reportarlo.")
                    End Try
                    coordenada = coordenada + 30
                    IMP &= "@" & coordenada & ",50:MF204,VMULT1|" & Lpad(pante4, "0", 3) & "       " & Lpad(lote4, "0", 3) & " " & VARIEDAD_DESC & " " & fechaq4.Substring(0, 2) & "/" & fechaq4.Substring(2, 2) & "/" & fechaq4.Substring(4, 4) & "        " & horaq4.Substring(0, 2) & ":" & horaq4.Substring(2, 2) & "         " & Lpad(unidad4.Text, "0", 3) & "|"
                End If
            End If
            coordenada = coordenada + 30
            If ((tipot.Text = "C") Or (tipot.Text = "G")) Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR            UNADAS      FECHA CORTE      EQUIVALENCIA|"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 35)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "    " & linea.Substring(3, 3) & "        " & linea.Substring(6, 6) & "  " & linea.Substring(29, 6) & "         " & linea.Substring(12, 3) & "      " & linea.Substring(15, 2) & "/" & linea.Substring(17, 2) & "/" & linea.Substring(19, 4) & "       " & linea.Substring(23, 6) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(12, 3))
                    If ((salto = 25) Or (salto = 50)) Then
                        IMP &= "}" & "{AHEAD:0}" & "{LP}"
                        BTPRINT.Write(IMP)
                        IMP = Chr(27) & "EZ" & "{PRINT: "
                        coordenada = 0
                    End If
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1

                End While
                ''temporal erick''
                'If trato.Checked = True Then
                '    coordenada = coordenada + 30
                '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                                  " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "             |"
                'End If
                ''
            ElseIf (tipot.Text = "L") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |FILA   POSICION   CORTADOR            QUINTALES      FECHA CORTE      EQUIVALENCIA|"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 35)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 35, 35)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "    " & linea.Substring(3, 3) & "        " & linea.Substring(6, 6) & "  " & linea.Substring(29, 6) & "         " & linea.Substring(12, 3) & "      " & linea.Substring(15, 2) & "/" & linea.Substring(17, 2) & "/" & linea.Substring(19, 4) & "       " & linea.Substring(23, 6) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(12, 3))
                    If ((salto = 25) Or (salto = 50)) Then
                        IMP &= "}" & "{AHEAD:0}" & "{LP}"
                        BTPRINT.Write(IMP)
                        IMP = Chr(27) & "EZ" & "{PRINT: "
                        coordenada = 0
                    End If
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1

                End While
                ''temporal erick''
                'If trato.Checked = True Then
                '    coordenada = coordenada + 30
                '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                                  " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "             |"
                'End If
                ''
            ElseIf ((tipot.Text = "T") Or (tipot.Text = "T")) Then
                If tipot.Text = "T" Then
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      EQUIVALENCIA      FECHA CORTE|"
                    'MsgBox(detalle.Text.Length / 12)
                    corte = (detallet.Text.Length / 20)
                    salto = 1
                    LecturaF.Text = 0
                    'MsgBox(corte)
                    While salto <= corte
                        linea = ""
                        coordenada = coordenada + 30
                        linea = detallet.Text.Substring(LecturaF.Text * 20, 20)
                        'MsgBox("linea: " & linea)
                        'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                        IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "        " & linea.Substring(6, 6) & "            " & linea.Substring(12, 2) & "/" & linea.Substring(14, 2) & "/" & linea.Substring(16, 4) & "|"
                        salto = salto + 1
                        LecturaF.Text = LecturaF.Text + 1
                    End While
                    ''temporal erick''
                    'If trato.Checked = True Then
                    '    coordenada = coordenada + 30
                    '    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |                                " & Lpad(fecha_corte.Text.Substring(0, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(2, 2), "0", 2) & "/" & Lpad(fecha_corte.Text.Substring(4, 4), "0", 4) & "|"
                    'End If
                    ''
                End If
                total_detalle = total_unidades
            ElseIf (tipot.Text = "M") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADORA      TRACTOR      CARRETAS      O. CORTADORA      O. TRACTOR|"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 21)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 21, 21)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 3) & "            " & linea.Substring(3, 3) & "           " & linea.Substring(6, 3) & "           " & linea.Substring(9, 6) & "           " & linea.Substring(15, 6) & "|"
                    ' total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
                total_detalle = total_unidades
            ElseIf (tipot.Text = "U") Then
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      CANASTAS |"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 9)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 9, 9)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "            " & linea.Substring(6, 3) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
            ElseIf (tipot.Text = "V") Then
                'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |CORTADOR      CANASTAS |"
                'MsgBox(detalle.Text.Length / 12)
                corte = (detallet.Text.Length / 12)
                salto = 1
                LecturaF.Text = 0
                'MsgBox(corte)
                total_detalle = 0
                While salto <= corte
                    linea = ""
                    'coordenada = coordenada + 30
                    linea = detallet.Text.Substring(LecturaF.Text * 12, 12)
                    'MsgBox("linea: " & linea)
                    'MsgBox(lectura * 12 & " posiciones " & (salto * 12))
                    'IMP &= "@" & coordenada & ",50:MF204, VMULT1 |" & linea.Substring(0, 6) & "            " & linea.Substring(6, 3) & "|"
                    total_detalle = total_detalle + Convert.ToInt32(linea.Substring(6, 3))
                    TOTAL_SACOS = TOTAL_SACOS + Convert.ToInt32(linea.Substring(9, 3))
                    salto = salto + 1
                    LecturaF.Text = LecturaF.Text + 1
                End While
            End If
            If tipot.Text = "M" Then
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & cortadores.Text & " |"
            ElseIf tipot.Text = "L" Then
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & unidad.Text & " |"
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL QUINTALES:  " & total_detalle & " |"
                coordenada = coordenada + 30
                total_tonelada = total_detalle / 20
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL TONELADAS:  " & total_tonelada & " |"
            Else
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL " & unidades.Text & ": " & total_detalle & " |"
            End If
            If tipot.Text = "V" Then
                coordenada = coordenada + 50
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TOTAL SACOS: " & TOTAL_SACOS & " |"
            End If
            coordenada = coordenada + 30
            IMP &= "@" & coordenada & ",50:MF204, VMULT1 |ENVIERO:      " & Lpad(usuario.Text, "0", 6) & " |"
            If (tipot.Text = "L") Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ",50:MF204, VMULT1 |TIPO:     " & texto & " |"
            End If
            If tipot.Text = "G" Or tipot.Text = "C" Or tipot.Text = "T" Then
                coordenada = coordenada + 30
                IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | TOTAL DE CORTADORES INGRESADOS : " & cortadores.Text & "|"
            End If
            If tipot.Text = "M" Then
                Dim TOTAL_CARRETAS As Integer = 0
                TOTAL_CARRETAS = Convert.ToInt32(cortadores.Text.Trim)
            End If
            coordenada = coordenada + 50
            IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | IMPRESION NUMERO : ** PREVIA ** |"
            coordenada = coordenada + 50
            IMP &= "@" & coordenada & ", 50:MF204, VMULT1 | UBICACION : " & txtLatitud.Text & ", " & txtLongitud.Text & ", " & txtResult.Text & "|"
            coordenada = coordenada + 50

            IMP &= "}" & "{AHEAD:125}" & "{LP}"
            BTPRINT.Write(IMP)
            BTPRINT.Close()
        Catch ex As Exception
            MsgBox("Error ocacionado por 18" & ex.Message & vbCrLf & "Favor de Reportarlo.")
        End Try
        IMPRESIONPRE = IMPRESIONPRE + 1
        
    End Sub


    Private Sub f_bloquea_campos()
        Previa.Enabled = False
        Filas.Enabled = False
        posi.Enabled = False
        corta.Enabled = False
        racimo.Enabled = False
        op_alz.Enabled = False
        op_trac.Enabled = False
        Agregar.Enabled = False
        Borrar.Enabled = False
        editar.Enabled = False
        id_contratista.Enabled = False
        contraid.Enabled = False
        fecha_corte.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        ALZ.Enabled = False
        OPA.Enabled = False
        TRA.Enabled = False
        OPT.Enabled = False
        ENV.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        scanner.Enabled = False
        Nboleta.Enabled = False
        peri.Enabled = False
        trans.Enabled = False
        vehi.Enabled = False
        pilo.Enabled = False
        ruta.Enabled = False
        plata.Enabled = False
        cole.Enabled = False
        DateTimePicker5.Enabled = False
        equivalencia.Enabled = False
        Manual.Enabled = False
        Button1.Enabled = False
        Id_finca.Enabled = False
        Id_Frente.Enabled = False
        Ho_des.Enabled = False
        Liturno.Enabled = False
        ruta.Enabled = False
        lipa1.Enabled = False
        lilo1.Enabled = False
        unidad.Enabled = False
        fe_quema.Enabled = False
        DateTimePicker1.Enabled = False
        Ho_quema.Enabled = False
        presenta.Enabled = False
        fecturno.Enabled = False
        Button4.Enabled = False
        Establecer.Enabled = False
        Lizona.Enabled = False
        ocorte.Enabled = False
        Croquis.Enabled = False
        SerieCroquis.Enabled = False
        Granel.Enabled = False
        Mecanizado.Enabled = False
        Maleteado.Enabled = False
        Colera.Enabled = False
        Trameado.Enabled = False
        Maleteado_Colera.Enabled = False
        siguiente.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
    End Sub

    Private Sub Filas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Filas.KeyPress
        'corta.ForeColor = Color.White
        'corta.Text = "1234"
        'Filas.Text = ""
        'racimo.Text = ""
        'corta.Text = ""
        'posi.Text = ""
        'Filas.Text = ""
        Filas.ForeColor = Color.Black
        Filas.Focus()
    End Sub
    Private Sub txtPante_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPante.LostFocus
        If ((Id_Frente.Text = "") Or (Id_Frente.Text = "0")) Then
            MsgBox("<<Campo Frente Obligatorio>>")
        Else
            Dim valor As Integer = Nothing
            If txtPante.Text.Length > 0 Then
                Try
                    valor = Convert.ToInt32(txtPante.Text)
                    If valor < 0 Then
                        MsgBox("ingrese numeros")
                        txtPante.Focus()
                    End If
                Catch ex As Exception
                    MsgBox("Ingrese numeros")
                    txtPante.Focus()
                    txtPante.Text = "0"
                End Try
            End If
        End If
    End Sub

    Private Sub txtLote_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLote.LostFocus
        Dim valor As Integer = Nothing
        Try
            valor = Convert.ToInt32(txtLote.Text)
            If valor < 0 Then
                MsgBox("ingrese numeros")
                txtLote.Focus()
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            txtLote.Focus()
            txtLote.Text = "0"
        End Try
    End Sub

    Private Sub unidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unidad.TextChanged
        valida_lote()
    End Sub
    Private Sub f_valida_fecha_corte()
        Dim fecha_comp As Date
        fecha_comp = fecturnop.Text.Substring(0, 8)
        If ((Convert.ToDateTime(fecha_corte.Text)) < (Convert.ToDateTime(fecha_comp).AddDays(-2))) Then
            MsgBox("Fecha Corte muy atrasada <<Verifique>>")
            '  fecturno.Text = fecturnop.Text.Substring(0, 12)
        End If
    End Sub

    Private Sub txtLote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLote.TextChanged
        valida_pante()
    End Sub
    Private Sub valida_pante()
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Try
            If (Id_finca.Text.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim valor_finca As Integer = Nothing
                Dim valor_pante As Integer = Nothing
                Dim valor_npante As String = ""
                Try
                    valor_finca = Convert.ToInt32(Id_finca.Text)
                    If valor_finca < 0 Then
                        MsgBox("Ingrese Finca")
                        Id_finca.Focus()
                    Else
                        valor_pante = Convert.ToInt32(txtPante.Text)
                        CONN.Open()
                        Dim QueryPant = New SqlCeCommand("Select count(id_pante) FROM TB_PANTES WHERE (ID_FINCA = " & valor_finca & ")AND(ID_PANTE = " & valor_pante & ");", CONN)
                        drl = QueryPant.ExecuteReader()
                        While drl.Read()
                            valor = drl(0).ToString
                        End While
                        valor_npante = CInt(valor)
                        If valor_npante > 0 Then
                            txtLote.Focus()
                        Else
                            MsgBox("Pante no Valido")
                            txtPante.Focus()
                            'txtPante.Text = "0"
                            txtLote.Text = ""
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error Codigo Pantes " & ex.Message & vbCrLf & "Favor Reportarlo.")
                    txtPante.Focus()
                    'txtPante.Text = "0"
                    txtLote.Text = ""
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error Codigo Pantes " & ex.Message & vbCrLf & "Favor Reportarlo.")
        End Try
        CONN.Close()
    End Sub
    Private Sub valida_lote()
        Dim dr As SqlCeDataReader = Nothing
        Dim drl As SqlCeDataReader = Nothing
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Try
            If (txtPante.Text.Length > 0) Then
                Dim valor As Integer = Nothing
                Dim valor_finca As Integer = Nothing
                Dim valor_pante As Integer = Nothing
                Dim valor_lote As Integer = Nothing
                Dim valor_nlote As String = ""
                Try
                    valor_finca = Convert.ToInt32(Id_finca.Text)
                    valor_pante = Convert.ToInt32(txtPante.Text)
                    If (valor_finca < 0) And (valor_pante > 0) Then
                        MsgBox("Ingrese Finca")
                        Id_finca.Focus()
                    ElseIf (valor_finca > 0) And (valor_pante < 0) Then
                        MsgBox("Ingrese Pante")
                        txtPante.Focus()
                    Else
                        valor_lote = Convert.ToInt32(txtLote.Text.Trim)
                        CONN.Open()
                        Dim QueryLot = New SqlCeCommand("Select count(id_lote) FROM TB_LOTES WHERE (ID_FINCA = " & valor_finca & ")AND(ID_PANTE = " & valor_pante & ")AND(ID_LOTE = " & valor_lote & ");", CONN)
                        drl = QueryLot.ExecuteReader()
                        While drl.Read()
                            valor = drl(0).ToString
                        End While
                        valor_nlote = CInt(valor)
                        If valor > 0 Then
                            fe_quema.Focus()
                        Else
                            MsgBox("Lote no Valido")
                            txtLote.Focus()
                            'txtLote.Text = "0"
                            fe_quema.Text = ""
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error Codigo Lotes " & ex.Message & vbCrLf & "Favor Reportarlo1.")
                    txtLote.Focus()
                    'txtLote.Text = "0"
                    fe_quema.Text = ""
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error Codigo Lotes " & ex.Message & vbCrLf & "Favor Reportarlo2.")
        End Try
        CONN.Close()
    End Sub
    Private Sub racimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles racimo.TextChanged
        If ((tipot.Text = "G") And (tipot.Text = "L") And (tipot.Text = "T")) Then
            Dim valor As Integer = Nothing
            If corta.Text.Length > 0 Then
                valor = Convert.ToInt32(corta.Text)
                If ((valor < 999) Or (valor > 90000)) Then
                    'If ((valor < 999) Or ((valor > 10000) And (valor < 40000)) Or (valor > 60000)) Then '
                    If ((valor <> 265) Or (valor <> 288)) Then
                        MsgBox("Empleado no valido")
                        corta.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        'corta.Text = "1234"
        racimo.Text = ""
        corta.Text = ""
        posi.Text = ""
        Filas.Text = ""
        Filas.Focus()
    End Sub

    Private Sub Mecanizado_Colera_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mecanizado_Colera.CheckedChanged
        If IMPRESIONPRE >= 1 Or IMPRESIONES2 >= 1 Then
            MsgBox("Ya tiene impresion no puede cambiar tipo envio")
            Pic_TurnoWar.Show()
        Else
            If Mecanizado_Colera.Checked = True Then
                tipot.Text = "M"
                cole_meca.Text = "1"
                cole_mal.Text = ""
                tipotserie = "M"
                'SERIE_ENVIO_NEW()
            End If
        End If
    End Sub

    Private Sub LinkLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel1.Click
        'Dim proceso As New System.Diagnostics.Process
        'With proceso
        '.StartInfo.FileName = "http://192.168.3.182/ELPILAR/"
        'End With
        If (pg_estado = 0) Then
            DataGridSeleccion.Visible = True
            f_llena_filaGrid()
            LinkLabel1.Text = "OK"
            pg_estado = 1
            DataGridSeleccion.BringToFront()
        ElseIf (pg_estado = 1) Then
            f_seleccion_filaGrid()
            DataGridSeleccion.Visible = False
            LinkLabel1.Text = "Ver Lista"
            pg_estado = 0
            DataGridSeleccion.SendToBack()
        End If
    End Sub
    Private Sub f_seleccion_filaGrid()
        If (DataGridSeleccion.VisibleRowCount = 0) Then
            MsgBox("No Tiene Croquis Sincronizados")
        Else
            Dim currentCell, currentCell2, currentCell3 As DataGridCell

            Dim currentCellData, currentCellData2, currentCellData3 As String
            ' Se obtiene la celda actual.
            currentCell = DataGridSeleccion.CurrentCell
            currentCell2 = DataGridSeleccion.CurrentCell
            currentCell3 = DataGridSeleccion.CurrentCell

            ' Se obtiene la data de la celda actual.
            'currentCellData = CStr(DataGridEncCro(currentCell.RowNumber, currentCell.ColumnNumber))
            currentCellData = CStr(DataGridSeleccion(currentCell.RowNumber, 0))
            currentCellData2 = CStr(DataGridSeleccion(currentCell2.RowNumber, 1))
            currentCellData3 = CStr(DataGridSeleccion(currentCell3.RowNumber, 2))

            ' Al TextBox se le asigna el valor de la celda actual.
            Filas.Text = currentCellData
            posi.Text = currentCellData2
            corta.Text = currentCellData3
        End If
    End Sub
    Private Sub f_llena_filaGrid()
        Try
            '--------------------------
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            ' Dim conexion As New clsConexion()
            Dim adaptador As SqlCeDataAdapter
            Dim dset As New DataSet()
            Dim sql As String

            CONN.Open()
            sql = "select fila, posicion, cortador, continua, uniadas, veces_utilizada, correlativo as # from tb_croquis_deta where serie =  '" + SerieCroquis.Text + "' AND croquis = " & Croquis.Text & " and estado_cro = 'ACT'  order by fila asc"
            adaptador = New SqlCeDataAdapter(sql, CONN)
            adaptador.Fill(dset, "tb_croquis_deta")
            DataGridSeleccion.DataSource = dset.Tables("tb_croquis_deta")
            CONN.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub txtPLaca_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLaca.LostFocus
        Dim valor As Decimal = Nothing
        Dim v_valor As Integer
        'Dim valor2 As Decimal = Nothing
        Try
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim fecha_c As DateTime
            Dim fecha_tem As String

            If tipot.Text = "L" Or tipot.Text = "T" Then
                p_placa = txtPLaca.Text.Trim
                '--------------------------------------------------------------
                Button1.Visible = True
                '------------------------------------------------------------
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                CONN.Open()
                Dim QueryEnv = New SqlCeCommand("Select count(envio) FROM TB_ENVIOS WHERE (PLACAS = '" + p_placa + "');", CONN)
                drl = QueryEnv.ExecuteReader()
                While drl.Read()
                    v_valor = drl(0).ToString
                End While
                If v_valor > 0 Then
                    '---------------------------------
                    Dim vr_CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                    'Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where transportista =" & Convert.ToInt32(t) & " AND vehiculo = " + v + ";", vr_CONN)
                    vr_CONN.Open()
                    Dim vr_QUERY = New SqlCeCommand("select DATEADD(minute, 30, MAX(FECHA_ENVIO)) as fecha from TB_ENVIOS where placas = '" + p_placa + "';", vr_CONN)
                    Dim vr_dr As SqlCeDataReader = Nothing
                    Dim vr_dr2 As SqlCeDataReader = Nothing

                    vr_dr = vr_QUERY.ExecuteReader
                    While vr_dr.Read
                        fecha_c = vr_dr(0)
                        'If fecha_c > Now.ToString("yyyyMMdd HH:mm") Then
                        fecha_tem = Now.ToString("dd/MM/yyyy HH:mm")
                        fecha_tem = DateTime.Now
                        ' fecha_sis = Now.ToString("dd/MM/yyyy HH:mm") ' Now.ToString("ddMMyyyyHHmmss")
                        If fecha_c > DateTime.Now Then ''Now.ToString("dd/MM/yyyy HH:mm:ss") Then
                            MsgBox("No tiene media hora de leido el envio")
                            txtPLaca.Text = ""
                            scanner.Focus()
                        End If
                    End While
                    vr_CONN.Close()
                    '---------------------------------
                End If
            End If
        Catch ex As Exception
            MsgBox("Ingrese numeros")
            'scanner.Focus()
        End Try
    End Sub

    Private Sub BtnVerCro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVerCro.Click
        'DataGridDetaCro.Visible = False
        'DataGridEncCro.Visible = True
        'Try
        '    '--------------------------
        '    Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        '    ' Dim conexion As New clsConexion()
        '    Dim adaptador As SqlCeDataAdapter
        '    Dim dset As New DataSet()
        '    Dim sql As String

        '    CONN.Open()
        '    sql = "select serie, croquis, fecha_quema as f_quema, hora_quema, fecha_corte as f_corte, orden_corte, id_planilla as planilla, id_finca as finca, id_pante as pante, id_lote as lote, id_frente frente, fila_de, fila_a, posicion_de, posicion_a from tb_croquis where estado = 'ACT' order by croquis desc"
        '    'sql = "select serie, croquis, fecha_quema as f_quema, hora_quema, fecha_corte as f_corte, orden_corte, id_planilla as planilla, id_finca as finca, id_pante as pante, id_lote as lote, id_frente frente, fila_de, fila_a, posicion_de, posicion_a from tb_croquis order by croquis desc"
        '    adaptador = New SqlCeDataAdapter(sql, CONN)
        '    adaptador.Fill(dset, "tb_croquis")
        '    DataGridEncCro.DataSource = dset.Tables("tb_croquis")
        '    CONN.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
        f_actualiza_listacroquis()
    End Sub
    Private Sub f_actualiza_listacroquis()
        DataGridDetaCro.Visible = False
        DataGridEncCro.Visible = True
        Try
            '--------------------------
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            ' Dim conexion As New clsConexion()
            Dim adaptador As SqlCeDataAdapter
            Dim dset As New DataSet()
            Dim sql As String

            CONN.Open()
            sql = "select serie, croquis, fecha_quema as f_quema, hora_quema, fecha_corte as f_corte, orden_corte, id_planilla as planilla, id_finca as finca, id_pante as pante, id_lote as lote, id_frente frente, fila_de, fila_a, posicion_de, posicion_a from tb_croquis where estado_cro = 'ACT' order by croquis desc"
            'sql = "select serie, croquis, fecha_quema as f_quema, hora_quema, fecha_corte as f_corte, orden_corte, id_planilla as planilla, id_finca as finca, id_pante as pante, id_lote as lote, id_frente frente, fila_de, fila_a, posicion_de, posicion_a from tb_croquis order by croquis desc"
            adaptador = New SqlCeDataAdapter(sql, CONN)
            adaptador.Fill(dset, "tb_croquis")
            DataGridEncCro.DataSource = dset.Tables("tb_croquis")
            CONN.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnDetalleCro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetalleCro.Click
        If (TxtTempSerie.Text = "") Then
            MsgBox("Seleccione Croquis")
        Else
            DataGridEncCro.Visible = False
            'DataGridEncCro.Enabled = False
            DataGridDetaCro.Visible = True

            Try
                '--------------------------
                Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
                ' Dim conexion As New clsConexion()
                Dim adaptador As SqlCeDataAdapter
                Dim dset As New DataSet()
                Dim sql As String

                CONN.Open()
                sql = "select fila, posicion, cortador, continua, uniadas, veces_utilizada, correlativo as # from tb_croquis_deta where serie =  '" + TxtTempSerie.Text + "' AND croquis = " & TxtTempCroquis.Text & "  order by fila asc"
                adaptador = New SqlCeDataAdapter(sql, CONN)
                adaptador.Fill(dset, "tb_croquis_deta")
                DataGridDetaCro.DataSource = dset.Tables("tb_croquis_deta")
                CONN.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub DataGridEncCro_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridEncCro.CurrentCellChanged
        If (DataGridEncCro.VisibleRowCount = 0) Then
            MsgBox("No Tiene Croquis Sincronizados")
        Else
            Dim currentCell, currentCell2 As DataGridCell

            Dim currentCellData, currentCellData2 As String
            ' Se obtiene la celda actual.
            currentCell = DataGridEncCro.CurrentCell
            currentCell2 = DataGridEncCro.CurrentCell

            ' Se obtiene la data de la celda actual.
            'currentCellData = CStr(DataGridEncCro(currentCell.RowNumber, currentCell.ColumnNumber))
            currentCellData = CStr(DataGridEncCro(currentCell.RowNumber, 0))
            currentCellData2 = CStr(DataGridEncCro(currentCell2.RowNumber, 1))
            ' Al TextBox se le asigna el valor de la celda actual.

            TxtTempSerie.Text = currentCellData
            TxtTempCroquis.Text = currentCellData2
        End If
    End Sub

    Private Sub BtnBackCro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBackCro.Click
        DataGridDetaCro.Visible = False
        DataGridEncCro.Visible = True
    End Sub

    Private Sub BtnOKCro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOKCro.Click
        f_lee_croquis()
    End Sub
    Private Sub f_lee_croquis()
        If (txtLeeCroqui.Text.Length <= 0) Then
            MsgBox("Lea QR")
        Else
            Dim dr As SqlCeDataReader = Nothing
            Dim drl As SqlCeDataReader = Nothing
            Dim vc_serie, vc_fecha_quema, vc_fec_quema, vc_hora_quema, vc_fecha_corte, vc_fec_corte, vc_fila_de, vc_dsc_filade, vc_fila_a, vc_dsc_filaa, vc_posicion_de, vc_dsc_posde, vc_posicion_a, vc_dsc_posa As String
            Dim vc_croquis, vc_planilla, vc_finca, vc_pante, vc_lote, vc_estado, vc_orden_corte, vc_frente As Integer

            Dim vc_dia, vc_mes, vc_anio, vc_comp01, vc_dia2, vc_mes2, vc_anio2, vc_comp02, v_estado_cro As String

            vc_serie = txtLeeCroqui.Text.Substring(5, 5)
            vc_croquis = txtLeeCroqui.Text.Substring(0, 5)
            vc_planilla = Convert.ToInt32(txtLeeCroqui.Text.Substring(10, 4))
            vc_finca = Convert.ToInt32(txtLeeCroqui.Text.Substring(14, 3))
            vc_pante = Convert.ToInt32(txtLeeCroqui.Text.Substring(17, 3))
            vc_lote = Convert.ToInt32(txtLeeCroqui.Text.Substring(20, 3))

            '-----------------------------------------fecha de quema
            vc_fecha_quema = txtLeeCroqui.Text.Substring(23, 10)
            vc_comp01 = vc_fecha_quema.Substring(3, 1)
            If (vc_comp01 = "-") Or (vc_comp01 = "/") Then
                vc_mes = "0" + vc_fecha_quema.Substring(4, 1)
                vc_dia = vc_fecha_quema.Substring(1, 2)
            Else
                vc_mes = vc_fecha_quema.Substring(3, 2)
                vc_dia = vc_fecha_quema.Substring(0, 2)
            End If
            vc_anio = vc_fecha_quema.Substring(6, 4)

            vc_fec_quema = vc_dia + "/" + vc_mes + "/" + vc_anio
            '-------------------------------------------------------

            vc_hora_quema = txtLeeCroqui.Text.Substring(33, 2) + ":" + txtLeeCroqui.Text.Substring(36, 2)

            '-----------------------------------------fecha de corte
            vc_fecha_corte = txtLeeCroqui.Text.Substring(41, 10)
            vc_comp02 = vc_fecha_corte.Substring(3, 1)
            If (vc_comp02 = "-") Or (vc_comp02 = "/") Then
                vc_mes2 = "0" + vc_fecha_corte.Substring(4, 1)
                vc_dia2 = vc_fecha_corte.Substring(1, 2)
            Else
                vc_mes2 = vc_fecha_corte.Substring(3, 2)
                vc_dia2 = vc_fecha_corte.Substring(0, 2)
            End If
            vc_anio2 = vc_fecha_corte.Substring(6, 4)

            vc_fec_corte = vc_dia2 + "/" + vc_mes2 + "/" + vc_anio2
            '-------------------------------------------------------
            vc_orden_corte = txtLeeCroqui.Text.Substring(51, 5)
            vc_fila_de = txtLeeCroqui.Text.Substring(56, 1)
            vc_fila_a = txtLeeCroqui.Text.Substring(57, 1)
            vc_posicion_de = txtLeeCroqui.Text.Substring(58, 1)
            vc_posicion_a = txtLeeCroqui.Text.Substring(59, 1)
            vc_frente = Convert.ToInt32(txtLeeCroqui.Text.Substring(61, 3))
            v_estado_cro = "ACT"

            '---------------------------
            If (vc_fila_de = "N") Then
                vc_dsc_filade = "NORTE"
            Else
                vc_dsc_filade = "SUR"
            End If
            '---------------------------
            If (vc_fila_a = "S") Then
                vc_dsc_filaa = "SUR"
            Else
                vc_dsc_filaa = "NORTE"
            End If
            '---------------------------
            If (vc_posicion_de = "P") Then
                vc_dsc_posde = "PONIENTE"
            Else
                vc_dsc_posde = "ORIENTE"
            End If
            '---------------------------
            If (vc_posicion_a = "O") Then
                vc_dsc_posa = "ORIENTE"
            Else
                vc_dsc_posa = "PONIENTE"
            End If
            '---------------------------

            vc_estado = 1

            '----------------------------------
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            Dim QUERY = New SqlCeCommand()
            Dim v_valor As Integer

            CONN.Open()
            Dim QueryCro = New SqlCeCommand("Select count(croquis) FROM TB_CROQUIS WHERE serie = '" + vc_serie + "' AND croquis = " & vc_croquis & ";", CONN)
            drl = QueryCro.ExecuteReader()
            While drl.Read()
                v_valor = drl(0).ToString
            End While
            CONN.Close()

            If (v_valor > 0) Then
                MsgBox("Croquis ya fue escaneado")
            Else
                Try
                    CONN.Open()
                    QUERY = New SqlCeCommand("INSERT INTO TB_CROQUIS(CROQUIS, SERIE, ID_PLANILLA, ID_FINCA, ID_PANTE, ID_LOTE, FECHA_QUEMA, HORA_QUEMA, FECHA_CORTE, ESTADO, ORDEN_CORTE, FILA_DE, FILA_A, POSICION_DE, POSICION_A, ID_FRENTE,ESTADO_CRO)VALUES(" & vc_croquis & ",'" + vc_serie + "'," & vc_planilla & "," & vc_finca & "," & vc_pante & "," & vc_lote & ",'" + vc_fec_quema + "','" + vc_hora_quema + "','" + vc_fec_corte + "'," & vc_estado & "," & vc_orden_corte & ",'" + vc_dsc_filade + "','" + vc_dsc_filaa + "','" + vc_dsc_posde + "','" + vc_dsc_posa + "'," & vc_frente & ", '" + v_estado_cro + "');", CONN)
                    QUERY.ExecuteNonQuery()
                    ' MsgBox("Encabezado Croquis grabado")
                Catch ex As Exception
                    MsgBox("Error insert croquis " & ex.Message & vbCrLf & _
                                "Notifique.")
                End Try
                CONN.Close()
                '----------------------------------Desgloce de detalle
                Dim v_detalle, v_linea, v_continua As String
                Dim v_salto, v_corte, v_lectura As Integer
                Dim v_fila, v_posicion, v_cortador As Integer
                v_detalle = txtLeeCroqui.Text.Substring(64)
                v_salto = 1
                v_lectura = 0
                v_corte = (v_detalle.Length / 13)
                While v_salto <= v_corte
                    v_linea = ""
                    v_linea = v_detalle.Substring(v_lectura * 13, 13)
                    '-------------------------------------------------
                    v_fila = Convert.ToInt32(v_linea.Substring(0, 3))
                    v_posicion = Convert.ToInt32(v_linea.Substring(3, 3))
                    v_cortador = Convert.ToInt32(v_linea.Substring(6, 6))
                    v_continua = Convert.ToString(v_linea.Substring(12, 1))
                    '--------------------------------------------------
                    Try
                        CONN.Open()
                        QUERY = New SqlCeCommand("INSERT INTO TB_CROQUIS_DETA(CROQUIS, SERIE,CORRELATIVO, FILA, POSICION, CORTADOR, CONTINUA, ESTADO, ESTADO_CRO)VALUES(" & vc_croquis & ",'" + vc_serie + "'," & v_salto & "," & v_fila & "," & v_posicion & "," & v_cortador & ",'" + v_continua + "'," & vc_estado & ",'" + v_estado_cro + "');", CONN)
                        QUERY.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox("Error insert deta croquis " & ex.Message & vbCrLf & _
                                    "Notifique.")
                    End Try
                    CONN.Close()
                    '-------------------------------------
                    v_salto = v_salto + 1
                    v_lectura = v_lectura + 1
                End While
                MsgBox("Datos Grabados")
                txtLeeCroqui.Text = ""
                '-----------------------------------------------------
            End If
        End If
    End Sub

    Private Sub lbl_SeleCroq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_SeleCroq.Click
        If (pg_estado_v2 = 0) Then
            DataGridSelCro.Visible = True
            f_llena_GridCroquis()
            lbl_SeleCroq.Text = "OK"
            pg_estado_v2 = 1
            DataGridSelCro.BringToFront()
        ElseIf (pg_estado_v2 = 1) Then
            f_seleccion_GridCroquis()
            DataGridSelCro.Visible = False
            lbl_SeleCroq.Text = "Selec.."
            pg_estado_v2 = 0
            DataGridSelCro.SendToBack()
            f_name_finca()
        End If
    End Sub
    Private Sub f_llena_GridCroquis()
        Try
            '--------------------------
            Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
            ' Dim conexion As New clsConexion()
            Dim adaptador As SqlCeDataAdapter
            Dim dset As New DataSet()
            Dim sql As String

            CONN.Open()
            sql = "select serie, croquis, fecha_quema as f_quema, hora_quema, fecha_corte as f_corte, orden_corte, id_planilla as planilla, id_finca as finca, id_pante as pante, id_lote as lote, id_frente frente, fila_de, fila_a, posicion_de, posicion_a from tb_croquis where estado_cro = 'ACT' order by fecha_quema desc"
            adaptador = New SqlCeDataAdapter(sql, CONN)
            adaptador.Fill(dset, "tb_croquis")
            DataGridSelCro.DataSource = dset.Tables("tb_croquis")
            CONN.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub f_seleccion_GridCroquis()
        If (DataGridSelCro.VisibleRowCount = 0) Then
            MsgBox("No Tiene Croquis Sincronizados")
        Else
            ' Dim currentSerie, currentCroquis, currentFechaQuema, currentHora, currentFechaCorte, currentOrden, currentPlanilla, currentFinca, currentPante, currentLote, currentFrente As DataGridCell
            Dim currentSerie As DataGridCell

            Dim CellDataSerie, CellDataCroquis, CellDataFquema, CellDataHquema, CellDataFcorte, CellDataOcorte, CellDataPlanilla, CellDataFinca, CellDataPante, CellDataLote, CellDataFrente As String
            ' Se obtiene la celda actual.
            currentSerie = DataGridSelCro.CurrentCell
            'currentCroquis = DataGridSelCro.CurrentCell
            'currentFechaQuema = DataGridSelCro.CurrentCell
            'currentHora = DataGridSelCro.CurrentCell
            'currentFechaCorte = DataGridSelCro.CurrentCell
            'currentCell6 = DataGridSelCro.CurrentCell
            'currentCell7 = DataGridSelCro.CurrentCell
            'currentCell8 = DataGridSelCro.CurrentCell
            'currentCell9 = DataGridSelCro.CurrentCell

            ' Se obtiene la data de la celda actual.
            'currentCellData = CStr(DataGridEncCro(currentCell.RowNumber, currentCell.ColumnNumber))
            CellDataSerie = CStr(DataGridSelCro(currentSerie.RowNumber, 0))
            CellDataCroquis = CStr(DataGridSelCro(currentSerie.RowNumber, 1))
            CellDataFquema = CStr(DataGridSelCro(currentSerie.RowNumber, 2))
            CellDataHquema = CStr(DataGridSelCro(currentSerie.RowNumber, 3))
            CellDataFcorte = CStr(DataGridSelCro(currentSerie.RowNumber, 4))
            CellDataOcorte = CStr(DataGridSelCro(currentSerie.RowNumber, 5))
            CellDataPlanilla = CStr(DataGridSelCro(currentSerie.RowNumber, 6))
            CellDataFinca = CStr(DataGridSelCro(currentSerie.RowNumber, 7))
            CellDataPante = CStr(DataGridSelCro(currentSerie.RowNumber, 8))
            CellDataLote = CStr(DataGridSelCro(currentSerie.RowNumber, 9))
            CellDataFrente = CStr(DataGridSelCro(currentSerie.RowNumber, 10))

            ' Al TextBox se le asigna el valor de la celda actual.
            SerieCroquis.Text = CellDataSerie
            Croquis.Text = CellDataCroquis
            ocorte.Text = CellDataOcorte
            Id_finca.Text = CellDataFinca
            txtPante.Text = CellDataPante
            txtLote.Text = CellDataLote
            fe_quema.Text = CellDataFquema.Substring(0, 2) + CellDataFquema.Substring(3, 2) + CellDataFquema.Substring(6, 4)
            Ho_quema.Text = CellDataHquema.Substring(0, 2) + CellDataHquema.Substring(3, 2)
            Id_Frente.Text = CellDataFrente
        End If
    End Sub
    Private Sub f_name_finca()
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & NombreBaseDeDatos)
        Dim dr As SqlCeDataReader = Nothing
        Dim drp As SqlCeDataReader = Nothing
        Dim nfinca As Integer
        lipa1.Items.Clear()
        lilo1.Items.Clear()
        lipa2.Items.Clear()
        lilo2.Items.Clear()
        lipa3.Items.Clear()
        lilo3.Items.Clear()
        lipa4.Items.Clear()
        lilo4.Items.Clear()
        lipa5.Items.Clear()
        lilo5.Items.Clear()
        lipa6.Items.Clear()
        lilo6.Items.Clear()
        If Id_finca.Text.Length > 0 Then
            Try
                Dim valor As Integer = Nothing

                '---
                valor = Convert.ToInt32(Id_finca.Text)
                If valor < 0 Then
                    MsgBox("ingrese numeros")
                    nfinca = 0
                Else
                    nfinca = Convert.ToInt32(Id_finca.Text.Trim)
                    If tipot.Text <> "U" Then
                        Dim QUERYp = New SqlCeCommand("Select id_pante FROM TB_PANTES WHERE (ID_FINCA = " & nfinca & " AND estado = 'ACT' );", CONN)
                        Dim pantes As Integer = 0
                        CONN.Open()
                        drp = QUERYp.ExecuteReader()
                        While drp.Read()
                            lipa1.Items.Add(drp(0).ToString.Trim)
                            lipa2.Items.Add(drp(0).ToString.Trim)
                            lipa3.Items.Add(drp(0).ToString.Trim)
                            lipa4.Items.Add(drp(0).ToString.Trim)
                            lipa5.Items.Add(drp(0).ToString.Trim)
                            lipa6.Items.Add(drp(0).ToString.Trim)
                            pantes = pantes + 1
                        End While
                        If pantes = 0 Then
                            lipa1.Items.Add(0)
                            lipa2.Items.Add(0)
                            lipa3.Items.Add(0)
                            lipa4.Items.Add(0)
                            lipa5.Items.Add(0)
                            lipa6.Items.Add(0)
                        End If
                    ElseIf (tipot.Text = "U") Then
                        Dim QUERYQ = New SqlCeCommand("Select id_LOte FROM TB_LOTES WHERE (ID_FINCA = " & nfinca & " AND ID_PANTE = 1 AND estado = 'ACT' );", CONN)
                        Dim pantes1 As Integer = 0
                        CONN.Open()
                        drp = QUERYQ.ExecuteReader()
                        While drp.Read()
                            lipa1.Items.Add(drp(0).ToString.Trim)
                            lipa2.Items.Add(drp(0).ToString.Trim)
                            lipa3.Items.Add(drp(0).ToString.Trim)
                            lipa4.Items.Add(drp(0).ToString.Trim)
                            lipa5.Items.Add(drp(0).ToString.Trim)
                            lipa6.Items.Add(drp(0).ToString.Trim)
                            pantes1 = pantes1 + 1
                        End While
                        If pantes1 = 0 Then
                            lipa1.Items.Add(0)
                            lipa2.Items.Add(0)
                            lipa3.Items.Add(0)
                            lipa4.Items.Add(0)
                            lipa5.Items.Add(0)
                            lipa6.Items.Add(0)
                        End If
                    End If
                End If
                '---
                valor = Convert.ToInt32(Id_finca.Text)
                If valor < 0 Then
                    MsgBox("ingrese numeros")
                End If
                'SELECT NOMBRE FROM TB_FINCAS WHERE ID_FINCA = 
                Dim QUERY = New SqlCeCommand("SELECT NOMBRE, SLATITUD, SLONGITUD, NLATITUD, NLONGITUD, ELATITUD, ELONGITUD, OLATITUD, OLONGITUD, ID_TIPO_FINCA FROM TB_FINCAS WHERE ID_FINCA =" & Convert.ToInt32(Id_finca.Text.Trim) & " AND (ESTADO = 'ACT') AND (ID_ENTIDAD_EMPRESA = 1);", CONN)
                If Empresa.Text.Trim = "1" Then
                    QUERY = New SqlCeCommand("SELECT NOMBRE, SLATITUD, SLONGITUD, NLATITUD, NLONGITUD, ELATITUD, ELONGITUD, OLATITUD, OLONGITUD, ID_TIPO_FINCA FROM TB_FINCAS WHERE ID_FINCA =" & Convert.ToInt32(Id_finca.Text.Trim) & " AND (ESTADO = 'ACT') AND (ID_ENTIDAD_EMPRESA = 1);", CONN)
                Else
                    QUERY = New SqlCeCommand("SELECT NOMBRE, SLATITUD, SLONGITUD, NLATITUD, NLONGITUD, ELATITUD, ELONGITUD, OLATITUD, OLONGITUD, ID_TIPO_FINCA FROM TB_FINCAS WHERE ID_FINCA =" & Convert.ToInt32(Id_finca.Text.Trim) & " AND (ESTADO = 'ACT') AND (ID_ENTIDAD_EMPRESA > 6325);", CONN)
                End If

                'CONN.Open()
                dr = QUERY.ExecuteReader()
                While dr.Read()
                    Nombre_finca.Text = dr(0).ToString
                    tipo_finca.Text = dr(9).ToString
                    txtLat1.Text = Replace(Replace(dr(1).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLon1.Text = Replace(Replace(dr(2).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLat2.Text = Replace(Replace(dr(7).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLon2.Text = Replace(Replace(dr(8).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLat3.Text = Replace(Replace(dr(3).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    txtLon3.Text = Replace(Replace(dr(4).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    TxtLat4.Text = Replace(Replace(dr(5).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                    TxtLon4.Text = Replace(Replace(dr(6).ToString, "!", Chr(39)), "|", Chr(39) + Chr(39))
                End While
                'If Nombre_finca.TextLength > 0 Then
                '    Id_Frente.Focus()
                'Else
                '    Id_finca.Focus()
                'End If
            Catch ex As Exception
                MsgBox("Ingrese numeros")
                Id_finca.Focus()
                Id_finca.Text = "0"
                MsgBox("Error ocasionado por 4" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
        End If
        CONN.Close()
    End Sub

    Private Sub Sticker_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sticker.CheckStateChanged
        If Sticker.CheckState = Windows.Forms.CheckState.Checked Then
            'txtPLaca.Visible = True
            'scanner.Text = ""
            ' scanner.Visible = False
            v_sticket = 1
        ElseIf Sticker.CheckState = Windows.Forms.CheckState.Unchecked Then
            'txtPLaca.Visible = False
            'txtPLaca.Text = ""
            'scanner.Visible = True
            v_sticket = 0
        End If
    End Sub

    Private Sub btnFinCroquis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinCroquis.Click
        Dim pregunta As Integer
        Dim CONN = New SqlCeConnection("Data Source = " & DirectorioDeAplicacion & BASEINS)
        Dim v_estado As String
        v_estado = "FIN"

        pregunta = MsgBox("Esta seguro que quiere continuar?", MsgBoxStyle.YesNo)
        If pregunta = vbYes Then
            Dim QUERY = New SqlCeCommand("UPDATE TB_CROQUIS SET  estado_cro ='" + v_estado + "' Where serie = '" + TxtTempSerie.Text + "' AND croquis = " & TxtTempCroquis.Text & ";", CONN)
            'Dim dr As SqlCeDataReader = Nothing
            Dim REGISTROS As Integer
            Try
                CONN.Open()
                If CONN.State = Data.ConnectionState.Open Then
                    REGISTROS = QUERY.ExecuteNonQuery
                End If
            Catch ex As Exception
                MsgBox("Error actualizar estado croquis" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
            '---------------------------------------------------------------------------------
            Dim QUERY2 = New SqlCeCommand("UPDATE TB_CROQUIS_DETA SET  estado_cro ='" + v_estado + "' Where serie = '" + TxtTempSerie.Text + "' AND croquis = " & TxtTempCroquis.Text & ";", CONN)
            'Dim dr As SqlCeDataReader = Nothing
            Dim REGISTROS2 As Integer
            Try
                CONN.Open()
                If CONN.State = Data.ConnectionState.Open Then
                    REGISTROS2 = QUERY.ExecuteNonQuery
                End If
            Catch ex As Exception
                MsgBox("Error actualizar estado detalle croquis" & ex.Message & vbCrLf & _
                            "Favor de reportarlo.")
            End Try
            CONN.Close()
        Else
            BtnVerCro.Focus()
        End If
    End Sub
End Class
