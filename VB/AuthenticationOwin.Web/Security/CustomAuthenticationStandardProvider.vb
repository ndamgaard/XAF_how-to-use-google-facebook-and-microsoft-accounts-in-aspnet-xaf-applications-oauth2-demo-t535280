﻿Imports Microsoft.VisualBasic
Imports AuthenticationOwin.Module
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace AuthenticationOwin.Web.Security
	Public Class CustomAuthenticationStandardProvider
		Inherits AuthenticationStandardProvider
		Public Sub New(ByVal userType As Type)
			MyBase.New(userType)
		End Sub
		Public Overrides Function Authenticate(ByVal objectSpace As IObjectSpace) As Object
			Dim user As IAuthenticationOAuthUser = TryCast(MyBase.Authenticate(objectSpace), IAuthenticationOAuthUser)
			If user IsNot Nothing AndAlso (Not user.EnableStandardAuthentication) Then
				Throw New InvalidOperationException("Password authentication is not allowed for this user.")
			End If
			Return user
		End Function
	End Class
End Namespace