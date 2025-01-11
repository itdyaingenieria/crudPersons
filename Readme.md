# Proyecto .NET MVC: CRUD de Personas Ejercicio 

Este proyecto es una aplicación web desarrollada en .NET Framework/Core con el patrón MVC, que implementa un CRUD (Crear, Leer, Actualizar, Eliminar) para gestionar una tabla de "Personas". Utiliza Entity Framework para manejar la base de datos y cuenta con migraciones para versionar cambios en el esquema.

---

## **Requisitos previos**

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- **Visual Studio 2022** con la carga de trabajo de desarrollo web.
- **SQL Server** (o la base de datos configurada en `appsettings.json`).

---

## **Configuración inicial**

1. **Clonar el repositorio**  
   ```bash
   git clone https://github.com/itdyaingenieria/crudPersons.git
   cd <NOMBRE_DEL_PROYECTO>
   ```

2. **Configurar la cadena de conexión**  
   Abre el archivo `appsettings.json` y edita la sección `ConnectionStrings` con los datos de tu servidor SQL:

   ```json
      "ConnectionStrings": {
        "DFYAConnection": "Server=localhost\\SQLEXPRESS;Database=<NOMBRE_BASE_DATOS>;Trusted_Connection=True;TrustServerCertificate=True;"
    }
   ```

---

## **Migraciones y base de datos**

Este proyecto utiliza **Entity Framework Code First** para manejar la base de datos.

### **Generar las migraciones**

Si realizas cambios en los modelos de datos, sigue estos pasos para generar y aplicar migraciones desde Visual Studio 2022:

1. Abre la **Consola del Administrador de Paquetes** en Visual Studio desde el menú:
   ```
   Herramientas > Administrador de paquetes NuGet > Consola del Administrador de Paquetes
   ```

2. Generar una nueva migración:
   ```powershell
   Add-Migration NombreDeLaMigracion
   ```

3. Aplicar las migraciones a la base de datos:
   ```powershell
   Update-Database
   ```

---

## **Ejecución del proyecto**

Para ejecutar el proyecto localmente:

1. Asegúrate de que tu base de datos esté configurada y migrada.
2. Presiona `F5` o haz clic en el botón de **Iniciar depuración** en Visual Studio.
3. Abre tu navegador y navega a `http://localhost:<PUERTO>` (el puerto será indicado en la consola de salida de Visual Studio).

---

## **Despliegue**

### **Despliegue en IIS**
1. Publica el proyecto desde Visual Studio:
   - Ve a `Compilar > Publicar`.
   - Configura la publicación seleccionando `Folder` como destino.
   - Guarda los archivos en una carpeta de tu elección.

2. Configura IIS:
   - Crea un nuevo **Sitio web** en IIS apuntando a la carpeta publicada.
   - Configura el **Application Pool** para usar `.NET CLR v4.0` o superior.

3. Asegúrate de que el sitio web sea accesible a través de la red configurando los permisos necesarios.

### **Despliegue en Azure App Services**
1. Publica el proyecto seleccionando `Azure` como destino desde Visual Studio.
2. Configura el servicio en el portal de Azure con el plan adecuado para aplicaciones web.

---

## **Funcionalidades del CRUD**

1. **Crear Persona**  
   Permite agregar una nueva persona a la base de datos desde un formulario.

2. **Listar Personas**  
   Muestra una tabla con todas las personas registradas, incluyendo opciones de edición y eliminación.

3. **Editar Persona**  
   Permite modificar la información de una persona existente.

4. **Eliminar Persona**  
   Elimina una persona seleccionada de la base de datos.

---

## **Estructura del proyecto**

- **Controllers**: Controladores para manejar la lógica del CRUD.
- **Models**: Modelos de datos representando la entidad `Persona`.
- **Views**: Vistas Razor para las operaciones de CRUD.
- **Migrations**: Carpeta que contiene las migraciones generadas por Entity Framework.

---

## **Contribuciones**

Si deseas contribuir al proyecto:

1. Haz un fork del repositorio.
2. Crea una rama para tu funcionalidad o corrección de error (`git checkout -b nombre-rama`).
3. Realiza un pull request cuando tu trabajo esté listo.

---

## **Licencia**

Este proyecto se distribuye bajo la licencia [MIT](LICENSE).
