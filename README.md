# 📘 CreditelApp

Aplicación web para el registro y consulta de créditos, con envío automático de correos al registrar un nuevo crédito.  
Desarrollada como prueba técnica utilizando **.NET 9**, **React + Vite + TypeScript**, y **PostgreSQL**.

---

## 🧩 Características principales

- ✅ **Formulario de registro** de créditos (cliente, cédula, valor, interés, plazo, comercial).
- 📧 **Envío automático de correo** al registrar un nuevo crédito.
- 📋 **Listado de créditos** registrados en tabla.
- 🔍 **Filtros por cliente, cédula o comercial.**
- 💾 Conexión a base de datos **PostgreSQL**.

---

## 🚀 Ejecución del Backend (.NET + PostgreSQL)

### Configurar la base de datos
Crea una base de datos en PostgreSQL, por ejemplo:

```sql
CREATE DATABASE creditelapp;
```

### Configurar variables de entorno

En el archivo `appsettings.json` o `.env` (según tu estructura), actualiza con tus datos reales:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=creditelapp;Username=postgres;Password=tu_contraseña"
},

```

### Ejecutar las migraciones
```bash
dotnet ef database update
```

### Ejecutar el servidor
```bash
dotnet run
```

El backend se ejecutará por defecto en:
```
https://localhost:7196
```

---

## 💻 Ejecución del Frontend (React + Vite + TypeScript)

### Instalar dependencias
```bash
npm install
```

### Configurar variable de entorno

Crea un archivo `.env` en la raíz del frontend con la URL del backend:

```
VITE_API_URL=https://localhost:7196/api
```

### Ejecutar la aplicación
```bash
npm run dev
```

Por defecto se ejecutará en:
```
http://localhost:5173
```

---

## 🧪 Prueba del flujo

1. Ingresa al frontend en el navegador.  
2. Completa el formulario con los datos del crédito.  
3. Haz clic en **Registrar Crédito**.  
4. El sistema:
   - Guarda el crédito en la base de datos.
   - Envía un correo automático a `fyasocialcapital@gmail.com`.
   - Seleccionar la opción "Consultar registros" que muestra el crédito en la tabla con opción de filtros.

---

## 👨‍💻 Autor

**Daniel Meza**  
📧 [dmeza2021@gmail.com](mailto:dmeza2021@gmail.com)
