
# Sistema de Inventario (Invent-Engine)

Aplicación de escritorio en **C# / Windows Forms (.NET 10)** para gestionar productos, categorías y suplidores de un inventario, con papelera (borrado lógico), reportes y gráficos. Los datos se guardan en **SQL Server** (LocalDB por defecto).

Proyecto 1 de **ISW-124 Programación Avanzada**.

## Capturas de pantalla

| Inicio | Productos |
|:---:|:---:|
| <img width="480" alt="Inicio" src="https://github.com/user-attachments/assets/358147da-1a89-4818-9ac1-0b2baaf89d40" /> | <img width="480" alt="Productos" src="https://github.com/user-attachments/assets/1b0fadec-61a5-4fc3-90b5-34fd612ccedf" /> |

| Categorías | Suplidores |
|:---:|:---:|
| <img width="480" alt="Categorías" src="https://github.com/user-attachments/assets/cbe15002-0397-4bc5-b4c4-3a9255ba7581" /> | <img width="480" alt="Suplidores" src="https://github.com/user-attachments/assets/2fea81cc-df5a-4da3-b286-21d9932c6c7c" /> |

| Papelera | Reportes |
|:---:|:---:|
| <img width="480" alt="Papelera" src="https://github.com/user-attachments/assets/c2774df7-d7f4-4305-a21a-53d393a27cd2" /> | <img width="480" alt="Reportes" src="https://github.com/user-attachments/assets/7d966ca3-3475-45ba-8442-a66d8289a2e3" /> |

## Video demostrativo

https://universidaduce-my.sharepoint.com/:v:/g/personal/jg2024-0823_uce_edu_do/IQCxJrysDzDlQbUJTOa7EdmeAZV9J_gjLdOfV4qP4xEqo2A?nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&e=h6lREm

[![Ver video demostrativo](https://img.youtube.com/vi/ID_DEL_VIDEO/hqdefault.jpg)](https://www.youtube.com/watch?v=ID_DEL_VIDEO)

▶️ Haz clic en la imagen para ver el video (X minutos): muestra el funcionamiento de la aplicación y explica la arquitectura por capas.

## Funcionalidades

- CRUD de productos, categorías (con hasta 5 fotos .jpg/.png de máx. 2 MB) y suplidores.
- Búsqueda en tiempo real y filtros combinables en productos (categoría, suplidor y rango de precio).
- Papelera: los registros eliminados se pueden restaurar (con validación de dependencias).
- Panel de inicio con indicadores y gráficos; reportes con tabla y gráfico.
- Validaciones por campo (teléfono dominicano 809/829/849, correo, URL, precios con 2 decimales).
- Registro de errores técnicos en `errores.log` junto al ejecutable.

## Requisitos

- Windows 10/11
- [.NET 10 SDK](https://dotnet.microsoft.com/download) (para compilar) o el runtime de **.NET 10 Desktop** (para ejecutar `/build`)
- SQL Server LocalDB (incluido con Visual Studio) o cualquier instancia de SQL Server
- Visual Studio 2022/2026 con la carga de trabajo *Desarrollo de escritorio con .NET* (opcional)

## Instalación

### 1. Crear la base de datos

Desde la **raíz del repositorio**, ejecuta los scripts en este orden (desde SSMS, Azure Data Studio o `sqlcmd`):

```powershell
sqlcmd -S "(localdb)\MSSQLLocalDB" -I -i database\schema.sql
sqlcmd -S "(localdb)\MSSQLLocalDB" -I -f 65001 -i database\datos.sql
```

- `schema.sql` crea la base `SistemaInventario` y sus tablas (es re-ejecutable: borra y recrea).
- `datos.sql` carga los datos de prueba (también es re-ejecutable: limpia las tablas y reinicia los Id).
- `-I` activa `QUOTED_IDENTIFIER`, necesario por los índices filtrados.
- `-f 65001` hace que `sqlcmd` lea el script como **UTF-8**. Sin esa opción, los acentos y la ñ se guardan dañados (por ejemplo, "LÃ¡cteos" en lugar de "Lácteos"). Si usas SSMS o Azure Data Studio no hace falta.

> Si usas otra instancia de SQL Server, cambia `(localdb)\MSSQLLocalDB` por el nombre de tu servidor.

### 2. Configurar la conexión

La cadena de conexión está en `src/SistemaInventario.Presentacion/Program.cs`:

```csharp
Server=(localdb)\MSSQLLocalDB;Database=SistemaInventario;Trusted_Connection=True;TrustServerCertificate=True;
```

Cámbiala si usas otra instancia de SQL Server.

### 3. Compilar y ejecutar

```powershell
cd src
dotnet build SistemaInventario.sln -c Release
dotnet run --project SistemaInventario.Presentacion
```

O abre `src/SistemaInventario.sln` en Visual Studio y presiona **F5**. La base de datos debe existir antes de ejecutar la aplicación.

### Ejecutable compilado

La carpeta `build/` contiene la versión Release. Se genera con:

```powershell
cd src
dotnet publish SistemaInventario.Presentacion -c Release -r win-x64 --self-contained false -o ..\build
```

Ejecuta `build\SistemaInventario.Presentacion.exe` (requiere el runtime de **.NET 10 Desktop** y que la base de datos exista).

## Arquitectura

Solución en **4 capas**, con dependencias en un solo sentido (Presentación → Lógica de negocio → Acceso a datos → Entidades). La capa de Presentación no referencia directamente a Acceso a datos: solo usa las interfaces de servicio que entrega `FabricaServicios`.

| Proyecto | Responsabilidad |
|---|---|
| `SistemaInventario.Entidades` | Clases del dominio (`Categoria`, `Producto`, `Suplidor`, `FotoCategoria`) sobre `EntidadBase` (Id, Activo, fechas). |
| `SistemaInventario.AccesoDatos` | ADO.NET con `Microsoft.Data.SqlClient`. `RepositorioBase<T>` genérico con borrado lógico, `ConexionBD` (singleton), `Logger`. |
| `SistemaInventario.LogicaNegocio` | Servicios, validaciones (`Validador`), `Resultado<T>` para devolver éxito o errores por campo, y `FabricaServicios` que compone las capas. |
| `SistemaInventario.Presentacion` | Windows Forms: `FormPrincipal` con menú lateral, vistas (`UserControl`), formularios de edición y controles de estilo reutilizables. |

Cada formulario/vista separa la **lógica** (`Nombre.cs`) del **diseño visual** (`Nombre.Designer.cs`), por lo que se puede abrir en el diseñador de Visual Studio.

```
SistemaInventario/
├── README.md
├── src/        código fuente de la solución
├── database/   schema.sql y datos.sql
├── docs/       diagramas ER y de clases (UML)
└── build/      ejecutable compilado en Release
```

## Patrones y técnicas aplicadas

| Requisito | Dónde se aplica |
|---|---|
| **Repository** con interfaz genérica | `IRepositorio<T>` y `RepositorioBase<T>` (AccesoDatos), más `CategoriaRepositorio`, `SuplidorRepositorio` y `ProductoRepositorio`. |
| **Singleton** | `ConexionBD.Instancia` entrega la configuración de conexión a todos los repositorios. |
| **Inyección de dependencias por constructor** | Cada servicio recibe sus repositorios por constructor; `FabricaServicios` crea y conecta todo. |
| **Genéricos propios** | `Resultado<T>`, `ItemReporte<TValor>`, `Graficos.Columnas<T>` / `Graficos.Dona<T>`, `FormularioEdicion.Procesar<T>`, además de `IRepositorio<T>` y `RepositorioBase<T>`. |
| **POO** | Herencia (`EntidadBase`, `RepositorioBase<T>`, `ServicioBase`, `FormularioEdicion`), interfaces para repositorios y servicios, encapsulamiento con propiedades y campos privados. |
| **Validaciones** | `Validador` (LogicaNegocio) con regex de correo y teléfono, URL, precio con 2 decimales y fotos; los errores se muestran con `ErrorProvider`. |
| **Manejo de excepciones** | Toda llamada a la base de datos captura `SqlException` y la convierte en `AccesoDatosException`; `Logger` escribe el detalle en `errores.log`. |

**Consultas LINQ principales:**

- Búsqueda parcial sin distinguir mayúsculas en categorías, suplidores y papelera (`Filtrar`, `Contains` con `OrdinalIgnoreCase`).
- Filtro combinado de productos por nombre, categoría, suplidor y rango de precios (`ProductoServicio.Filtrar`).
- Productos agrupados por categoría con conteo, incluyendo categorías sin productos (`GroupJoin`, en `ReporteServicio`).
- Top 5 de suplidores con más productos (`GroupJoin`, `OrderByDescending`, `Take`).
- Promedio de precios por categoría (`GroupBy`, `Join`, `Average`).
- Sincronización de fotos de una categoría (`Where`, `Select`, `ToHashSet`).

## Diagramas

- **Entidad-relación:** [`docs/diagrama-er.png`](docs/diagrama-er.png)
- **Clases (UML):**
  [entidades](docs/diagrama-clases-entidades.png) ·
  [acceso a datos](docs/diagrama-clases-datos.png) ·
  [lógica de negocio](docs/diagrama-clases-negocio.png) ·
  [presentación](docs/diagrama-clases-presentacion.png)
  (fuentes Graphviz en `docs/fuentes-uml/`)

![Entidades](docs/diagrama-clases-entidades.png)

## Solución de problemas

- *No se pudo conectar con la base de datos:* verifica que LocalDB esté iniciado (`sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "SELECT 1"`) y que la cadena de conexión de `Program.cs` coincida con tu servidor.
- *Cannot open database "SistemaInventario" requested by the login:* la base todavía no existe; ejecuta primero `database\schema.sql` y luego `database\datos.sql`.
- *Acentos dañados en los datos (por ejemplo "LÃ¡cteos"):* ejecutaste `datos.sql` sin `-f 65001`. Vuelve a ejecutarlo con esa opción (el script limpia y recarga los datos).
- *La aplicación no abre (`build\SistemaInventario.Presentacion.exe`):* instala el runtime de **.NET 10 Desktop**.
- Los detalles técnicos de cualquier error quedan en `errores.log`, junto al ejecutable.
