function BasicHello()
{
    alert("Hello World!");
}

function ParentFunction(callBack)
{
    console.log("In parent function");
    var name = prompt('Please enter your name.')
    callBack(name);
    console.log("Back to parent function");
}
function CallbackFunction(name)
{
    console.log('Hello ' + name);
    console.log('Calling back');
}
function GetPokemon()
{
    console.log('In getpokemon');
    let xhttp = new XMLHttpRequest();
    let pokemon = {};
    let name = document.querySelector('#pokemon').value;
    //the ready state of the xhttp object determines the state of the request:
    // 0 - uninitialized
    // 1 - loading (server connection established) the open method has been invoked
    // 2 - loaded (request received by server) send has been called
    // 3 - ineractive (processing request) response body is being received
    // 4 - complete (response received) 
    //the status code checks if the operation was successful
    xhttp.onreadystatechange = function (){
        if(this.readyState == 4 && this.status == 200)
        {
            //the method JSON.parse converts the response body to a JS object
            pokemon = JSON.parse(xhttp.responseText);
            document.querySelector('.pokemon img').setAttribute('src', pokemon.sprites.front_default);
            document.querySelectorAll('.pokemon caption').forEach((element) => element.remove());
            let caption = document.createElement('caption');
            caption.appendChild(document.createTextNode(pokemon.forms[0].name));
            document.querySelector('.pokemon').appendChild(
                caption
            );
            document.querySelector('#pokemon').value = '';
        }
    };
    //creates the request
    //first parameter is the http method, second is the url/endpoint, third sets whether the request is async
    // By making the request async, the end user will be able to interact with the page while waiting for server response
    // The A in AJAX
    xhttp.open("GET", 'https://pokeapi.co/api/v2/pokemon/'+name, true);
    //Sends the request, has an optional parameter of request body data
    xhttp.send();
}
function GetDigimon()
{
    let name = document.querySelector('#digimon').value;
    //Simplest form takes in the URL you'll be querying, you can add additional request initializations in an object as a second parameter
    //returns a promise, you convert the response to json (which returns a promise), 
    //then you take the converted response and update your page
    fetch(`https://digimon-api.vercel.app/api/digimon/name/${name}`)
        .then(response => response.json())
        .then(result => {
            document.querySelector('.digimon img').setAttribute('src', result[0].img);
            document.querySelectorAll('.digimon caption').forEach((element) => element.remove());
            let caption = document.createElement('caption');
            caption.innerHTML = result[0].name;
            document.querySelector('.digimon').appendChild(caption);
            document.querySelector("#digimon").value = '';
        });
}