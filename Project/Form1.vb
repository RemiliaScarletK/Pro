Public Class Form1
    Const Apple_Price As Double = 10.0, Lettuce_PRice As Double = 12.5, Tomato_Price As Double = 8.5, Ham_Price As Double = 20.0, Tuna_Price As Double = 18.5, Grain_Wheat As Double = 8, Honey_Oat As Double = 10.5, Discount As Double = 90 / 100

    Dim Price_Tag As String = "HK$"
    Dim Order, apple, lettuce, tomato, ham, tuna, totalsum, count As Integer


    Dim Record(999) As Double
    Dim SoldAmount() As Integer = {apple, lettuce, tomato, ham, tuna}

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim Name As String = txtCusHisName.Text
        Dim HisCount As Integer

        Do
            HisCount += 1
        Loop Until Name = lstHistory.Items(count - 1)
        MsgBox(Name & “ is found on line ” & HisCount)

    End Sub

    Private Sub btnClearAccum_Click(sender As Object, e As EventArgs) Handles btnClearAccum.Click
        count = 0
        totalsum = 0
        txtAverageSales.Clear()
        txtNumberofOrder.Clear()
        txtTotalSales.Clear()
        txtLargeSales.Clear()



    End Sub


    Private Sub btnMostPop_Click(sender As Object, e As EventArgs) Handles btnMostPop.Click
        Dim OrderAmount As Integer = 0
        Dim OrderCount() As String = {"apple", "lettuce", "tomato", "ham", "tuna"}
        Dim OrderName As String = ""
        For i As Integer = 0 To SoldAmount.Count - 1

            If SoldAmount(i) > OrderAmount Then
                OrderAmount = SoldAmount(i)
                OrderName = OrderCount(i)
            End If


        Next
        MsgBox("Most Popular Ingredients :" & OrderName)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, gpxOrderInfo.Enter
        lblApplePrice.Text = Price_Tag & Apple_Price
        lblLettucePrice.Text = Price_Tag & Lettuce_price
        lblTomatoPrice.Text = Price_Tag & Tomato_Price
        lblHamPrice.Text = Price_Tag & Ham_Price
        lblTunaPrice.Text = Price_Tag & Tuna_Price
        lblGrain.Text = Price_Tag & Grain_Wheat
        lblHoney.Text = Price_Tag & Honey_Oat
        'Assign label Info


        lblApplePrice.Visible = True
        lblLettucePrice.Visible = True
        lblTomatoPrice.Visible = True
        lblHamPrice.Visible = True
        lblTunaPrice.Visible = True
        'label Visible 

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAmount.Clear()
        txtName.Clear()
        ckxApple.Checked = False
        ckxHam.Checked = False
        ckxLettuce.Checked = False
        ckxTomato.Checked = False
        ckxTuna.Checked = False
        roxGrainWheat.Checked = False
        roxHoneyOat.Checked = False
        lstQuantity.SelectedIndex = 0
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim sum As Double
        Dim CheckName As Boolean, CheckIngredients As Boolean, CheckBread As Boolean, CheckList As Boolean


        If ckxApple.Checked Then  'Ingredients sum
            SoldAmount(0) += 1

            sum += Apple_Price
        End If

        If ckxLettuce.Checked Then
            SoldAmount(1) += 1
            sum += Lettuce_PRice
        End If

        If ckxTomato.Checked Then
            SoldAmount(2) += 1
            sum += Tomato_Price
        End If

        If ckxHam.Checked Then
            SoldAmount(3) = 1
            sum += Ham_Price
        End If

        If ckxTuna.Checked Then
            SoldAmount(4) += 1
            sum += Tuna_Price

        End If

        If roxGrainWheat.Checked Then   'Bread sum  
            sum += Grain_Wheat
        End If

        If roxHoneyOat.Checked Then
            sum += Honey_Oat
        End If

        sum *= (lstQuantity.SelectedItem)

        If sum >= 100 Then
            sum *= Discount
        End If




        Dim CheckErrorAns As String = ""
        Dim ErrorName As Boolean, ErrorIngredients As Boolean, ErrorBread As Boolean, ErrorQuantity As Boolean
        If (Not (IsNumeric(txtName.Text))) And txtName.Text.Length > 0 Then

            CheckName = True
        Else
            ErrorName = True
        End If

        If ckxApple.Checked Or ckxHam.Checked Or ckxLettuce.Checked Or ckxTomato.Checked Or ckxTuna.Checked Then
            CheckIngredients = True

        Else
            ErrorIngredients = True
        End If

        If roxGrainWheat.Checked Or roxHoneyOat.Checked Then
            CheckBread = True
        Else
            ErrorBread = True
        End If

        If lstQuantity.SelectedIndex >= 0 And lstQuantity.SelectedIndex <= 10 Then
            CheckList = True
        Else
            ErrorQuantity = True
        End If

        If ErrorName = True Then
            CheckErrorAns += "Enter A Vaild Name "
        End If
        If ErrorBread = True Then
            CheckErrorAns += "Choice A Bread"
        End If
        If ErrorIngredients = True Then
            CheckErrorAns += "Choice An Ingredients "
        End If
        If ErrorQuantity = True Then
            CheckErrorAns += "Choice Quantity"
        End If


        If CheckErrorAns.Length > 1 Then
            MsgBox(CheckErrorAns)
        End If

        If CheckName = True And CheckIngredients = True And CheckBread = True And CheckList = True Then         
            Console.WriteLine(count & sum)
            lstHistory.Items.Add(txtName.Text)
            txtAmount.Text = Price_Tag & sum
            Order += 1
            Record(count) = sum
            count += 1
        End If
        Dim LargetCount As Integer = 0


        If sum > LargetCount Then
                txtLargeSales.Text = sum
            End If


        totalsum += sum
        txtTotalSales.Text = totalsum
        txtNumberofOrder.Text = count
        AvgSales()

    End Sub


    Sub AvgSales()
        Dim avg As Double = totalsum / count
        txtAverageSales.Text = Math.Round(avg, 2)

    End Sub

    Private Sub btnConfirm_ClientSizeChanged(sender As Object, e As EventArgs) Handles btnConfirm.ClientSizeChanged

    End Sub
End Class
