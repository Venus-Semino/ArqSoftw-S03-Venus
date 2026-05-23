# VeryLike - Plataforma de Gestión de Películas

Este proyecto es una aplicación web desarrollada en **ASP.NET Core MVC** siguiendo una **Arquitectura en Capas** (Layered MVC pattern), diseñada para gestionar un catálogo de películas, realizar seguimientos de visualización (watchlists) y compartir calificaciones.

**Autor:** Venus Getsemaní Semino Alemán (Sunev)  
**Institución:** Tecnológico de Software - Ingeniería en Sistemas y Software


---

## Características Principales

- **Gestión de Usuarios:** Registro e inicio de sesión funcional utilizando almacenamiento local en `.json`.
- **Catálogo de Películas:** Visualización de películas con opciones de filtrado.
- **Detalles y Calificaciones:** Opción para ver detalles específicos de cada película y otorgar una calificación (1 a 5).
- **Administración:** Funcionalidad para agregar nuevas películas al catálogo o eliminarlas.
- **Almacenamiento Persistente:** Uso de archivos de texto (`usuarios.json` e `items.json`) simulando una base de datos, cumpliendo con los requerimientos de la asignatura de Arquitectura de Software.
- **Diseño Personalizado:** Interfaz gráfica estilizada con un tema oscuro (Dark Mode) y acentos de color modernos, alejándose del diseño genérico por defecto de Bootstrap.

---

## Arquitectura del Proyecto

El proyecto está estructurado en cuatro capas principales para mantener un código limpio, modular y fácilmente escalable:

1. **Dominio (`Catalogo.Domain`):** Contiene los modelos de negocio (`Usuario.cs`, `Item.cs`) y las firmas/interfaces de los repositorios.
2. **Infraestructura (`Catalogo.Infrastructure`):** Implementa las interfaces del dominio para leer, escribir y actualizar los datos en los archivos `.json`.
3. **Aplicación (`Catalogo.Application`):** Contiene la lógica de negocio interna y los servicios que actúan de puente.
4. **Presentación (`Catalogo.Presentation`):** Controladores y Vistas (Razor Pages) encargadas de interactuar con el usuario final.

---

## 📸 Capturas de Pantalla

*(Nota para la entrega: Coloca tus imágenes en la misma carpeta que este README o en una carpeta de imágenes y reemplaza la ruta entre paréntesis)*

### 1. Menú Principal y Navegación
> Vista del tema oscuro personalizado y la barra de navegación.

![Menú Principal](\Users\venus\OneDrive\Imágenes\Screenshots\Captura de pantalla 2026-05-23 113536.png)

### 2. Inicio de Sesión
> Vista del formulario para ingresar las credenciales del usuario.

![Inicio de Sesión]("C:\Users\venus\OneDrive\Imágenes\Screenshots\Captura de pantalla 2026-05-23 113736.png")

### 3. Registro de Usuario
> Formulario que guarda la información en `usuarios.json`.

![Registro de Usuario](\Users\venus\OneDrive\Imágenes\Screenshots\Captura de pantalla 2026-05-23 113549.png)

### 4. Catálogo de Películas
> Vista general de los ítems disponibles en la plataforma.

![Catálogo de Películas](C:\Users\venus\OneDrive\Imágenes\Screenshots\Captura de pantalla 2026-05-23 113837.png)

### 5. Detalles y Sistema de Calificación
> Vista individual de la película, mostrando su información y el selector para calificarla.

![Detalles y Calificación]("C:\Users\venus\OneDrive\Imágenes\Screenshots\Captura de pantalla 2026-05-23 113855.png")

---

---

## Declaración de Uso de Inteligencia Artificial (Cláusula IA)

Para la realización y perfeccionamiento de este proyecto, se utilizó asistencia de Inteligencia Artificial como herramienta pedagógica y de depuración (`debugging`). Sus principales aportes fueron:
- Localización y resolución de errores de compilación (incoherencias en `namespaces` y referencias de ensamblado).
- Asistencia en la implementación de la lectura y escritura de bases de datos locales en formato `.json` dentro de la capa de Infraestructura.
- Depuración del comportamiento del `ModelState` en los formularios de registro e inicio de sesión de ASP.NET Core.

Todo el código fue estructurado, comprendido y ensamblado bajo la lógica de Arquitectura en Capas solicitada para la asignatura.
