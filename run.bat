@echo off
chcp 65001 >nul
title Запуск WPF Лабораторная работа №1
cd /d "%~dp0WpfLabApp"
echo ========================================================
echo Запуск лабораторной работы №1 (WPF .NET 8)...
echo ========================================================
start "" ".\bin\Debug\net8.0-windows\WpfLabApp.exe"
exit
