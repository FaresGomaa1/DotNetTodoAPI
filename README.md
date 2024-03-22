# DotNetTodoAPI

DotNetTodoAPI is a RESTful API built using ASP.NET Core for managing todos, categories, tasks, and attachments.

## Features

- **Todos**: CRUD operations for managing todos, including tasks associated with todos and categories assigned to todos.
- **Categories**: CRUD operations for managing categories, including listing categories with their associated todos.
- **Tasks**: CRUD operations for managing tasks associated with todos.
- **Attachments**: CRUD operations for managing attachments associated with todos.

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/FaresGomaa1/DotNetTodoAPI.git
   ```

2. Navigate to the project directory:

   ```bash
   cd DotNetTodoAPI
   ```

3. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

4. Update the database:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

By default, the application will be hosted at `http://localhost:5000`.

## API Endpoints

- **Todos**
  - `GET /api/todo`: Get all todos
  - `GET /api/todo/{id}`: Get todo by ID
  - `POST /api/todo`: Create a new todo
  - `PUT /api/todo/{id}`: Update todo by ID
  - `DELETE /api/todo/{id}`: Delete todo by ID

- **Categories**
  - `GET /api/category`: Get all categories
  - `GET /api/category/{id}`: Get category by ID
  - `POST /api/category`: Create a new category
  - `PUT /api/category/{id}`: Update category by ID
  - `DELETE /api/category/{id}`: Delete category by ID

- **Tasks**
  - `GET /api/tasks`: Get all tasks
  - `GET /api/tasks/{id}`: Get task by ID
  - `POST /api/tasks`: Create a new task
  - `PUT /api/tasks/{id}`: Update task by ID
  - `DELETE /api/tasks/{id}`: Delete task by ID

- **Attachments**
  - `GET /api/attachment`: Get all attachments
  - `GET /api/attachment/{id}`: Get attachment by ID
  - `POST /api/attachment`: Create a new attachment
  - `PUT /api/attachment/{id}`: Update attachment by ID
  - `DELETE /api/attachment/{id}`: Delete attachment by ID

- **Todo Categories**
  - `POST /api/todocategory`: Add category to todo
  - `DELETE /api/todocategory/{todoId}/{categoryId}`: Remove category from todo

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- C#
- Microsoft SQL Server

## Contributors

- Fares (@FaresGomaa1)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
