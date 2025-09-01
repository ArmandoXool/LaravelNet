# LaravelNet

**LaravelNet** es un mini IDE en **C# WinForms (.NET 6/7/8)** para explorar proyectos **Laravel** en Windows.

## 🎯 Objetivo
Permitir a los desarrolladores revisar la estructura de proyectos Laravel desde una interfaz ligera, con integración a Visual Studio Code para edición.

## 🚀 Funcionalidades actuales
- Selección de carpeta base (ejemplo: `C:\WebPHP744\htdocs`).
- Detección de proyectos Laravel (carpetas con `artisan` y `composer.json`).
- Explorador en **TreeView** con las carpetas principales:
  - `app/`
  - `resources/views/`
  - `routes/`
  - `database/migrations/`
  - `config/`

## 📌 Futuras funciones
- Integración con Artisan (`php artisan migrate`, `route:list`, etc).
- Editor simple de migraciones.
- Listado de endpoints activos.
- Apertura de archivos en VSCode.

## 🔧 Requisitos
- Windows 10/11
- Visual Studio 2022+
- .NET 6 o superior
- XAMPP con PHP 7.4+ instalado
- Visual Studio Code (opcional, para abrir archivos desde la app)

---
