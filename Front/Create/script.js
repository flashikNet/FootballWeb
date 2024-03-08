async function Post()  {
        const doc = document.querySelectorAll(".value-input")
        await fetch("http://localhost:5117/api/player", {
            method: "POST",
            body: JSON.stringify({
                name: doc[0].value,
                surname: doc[1].value,
                sex: doc[2].value,
                birthDate: doc[3].value,
                team: doc[4].value,
                country: doc[5].value
            }),
            headers: {
                "Content-type": "application/json"
            }
            });
        location.reload();

}

async function loadTeams(){
    const resp = await fetch("http://localhost:5117/api/teams");
    const teams = (await resp.json()).map(st => st["name"]);
    
    const teamsList = document.getElementById("teams")
    teams.forEach(element => {
        const team = document.createElement("option")
        team.value =  element
        teamsList.appendChild(team)
    });
}

loadTeams();
