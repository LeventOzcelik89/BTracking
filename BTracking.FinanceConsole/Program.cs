// See https://aka.ms/new-console-template for more information
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;

Console.WriteLine("Hello, World!");



//  var _commands = commands;
var _viewer = new WebView2();

_viewer.EnsureCoreWebView2Async(null);
_viewer.NavigationCompleted += new System.EventHandler<CoreWebView2NavigationCompletedEventArgs>((sender, e) => NavigationCompleteEvnt<T>(sender, e, method));
_viewer.Source = new Uri("url");


