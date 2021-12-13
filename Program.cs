var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var users = new List<Users>();
var index = 1;
var user = new Users("Juan Carlos", "Pereyra", 35);

user.Id = index; 

users.Add(user);

//GET ALL // MOSTRAR TODOS
app.MapGet("/api/users", () => users);

// GET // MOSTRAR POR ID
app.MapGet("/api/users/{id}", (int id) => {
    var user = users.FirstOrDefault(x => x.Id == id);
    return user; 
});

// CREATE // CREAR USUARIO
app.MapPost("/api/users" , (Users userInput) => {

    var exist = users.FirstOrDefault(x => x.Name.ToLower() == userInput.Name.ToLower() || x.Surname.ToLower() == userInput.Surname.ToLower()); 

    if(exist != null){
        return false; 
    }
    // userInput.Id = index++;
    index = index + 1 ;
    userInput.Id = index; 
    users.Add(userInput);
    return true; 
});

// EDIT ----- EDITAR USUARIO
app.MapPut("/api/users", (Users userInput) => {

    var user = users.FirstOrDefault(x => x.Id == userInput.Id);

    if (user == null){
        return false; 
    }
    users.Remove(user);
    users.Add(userInput);
    return true; 
});

//DELETE ----- BORRAR USUARIO

app.MapDelete("/api/users/{id}", (int id) => {
    var userDelete = users.FirstOrDefault(x => x.Id == id);
    if(userDelete == null){
        return false;
    }
    users.Remove(userDelete);
    return true;

});

app.Run();
