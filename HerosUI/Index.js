function getAllHeroes(){
    fetch('https://localhost:44331/SuperHero')
    .then(response => response.json())
    .then(result => {
        document.querySelectorAll('#heroes tbody tr').forEach((element) => element.remove());
        let table = document.querySelector('#heroes tbody');
        for (let i = 0; i<result.length(); ++i)
        {
            let row = table.insertRow(table.rows.length);
            let aliasCell = row.insertCell(0);
            aliasCell.innerHTML = result[i].alias;

            let realCell = row.insertCell(1);
            realCell.innerHTML = result[i].realName;

            let hideCell = row.insertCell(2);
            hideCell.innerHTML = result[i].hideOut;
        }
    });
};
function addAHero()
{
    let hero = {};
    hero.alias = document.querySelector('#alias').value;
    hero.realName = document.querySelector('#realName').value;
    hero.hideOut = document.querySelector('#hideOut').value;
    console.log(hero.alias);
    console.log(JSON.stringify(hero));

    let req = new XMLHttpRequest();
    req.onreadystatechange = () => {
        if(this.readyState == 4)
        {
            document.querySelector('#alias').value = '';
            document.querySelector('#realName').value ='';
            document.querySelector('#hideOut').value ='';
        }
    };
    req.open("POST", "url", true);
    req.setRequestHeader('Content-Type', 'application/json');
    req.send(JSON.stringify(hero));
};