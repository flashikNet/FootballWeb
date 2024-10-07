const countries = {
  "Russia": "Россия",
  "Italy": "Италия",
  "USA": "США",
  "США":"USA",
  "Италия":"Italy",
  "Россия":"Russia"

}

const genders = {
  "Male": "Мужской",
  "Female": "Женский",
  "Женский":"Female",
  "Мужской":"Male"
}
// Get the modal
const modal = document.getElementById("myModal");
const btn = document.querySelectorAll(".modal-button");
const span = document.getElementsByClassName("close")[0];

async function GetModal(self) {
  const forms = document.querySelectorAll(".value-input")
  const values = document.querySelectorAll(".c"+self.value)
  for (let index = 0; index < values.length; index++) {
    if (index == 2){
      forms[index].value = genders[values[index].innerHTML];
    } else if (index == 5){
      forms[index].value = countries[values[index].innerHTML];
    } else {
      forms[index].value = values[index].innerHTML;
    }
  }
  forms[6].value = self.value;
  modal.style.display = "block";
}

span.onclick = function() {
  modal.style.display = "none";
};

window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}

//Send request to edit player
async function Put()  {
  const doc = document.querySelectorAll(".value-input")
  await fetch("http://localhost:5117/api/players/edit", {
      method: "PUT",
      body: JSON.stringify({
          id: doc[6].value,
          name: doc[0].value,
          surname: doc[1].value,
          sex: doc[2].value,
          birthDate: doc[3].value,
          teamName: doc[4].value,
          country: doc[5].value
      }),
      headers: {
          "Content-type": "application/json"
      }
      });
  location.reload();
}

async function loadTeams(){
  const resp = await fetch("http://localhost:5117/api/teams/get");
  const teams = (await resp.json()).map(st => st["name"]);
  const teamsList = document.getElementById("teams")
  teams.forEach(element => {
    const team = document.createElement("option")
    team.value =  element
    teamsList.appendChild(team)
  });
}

async function loadPlayers(){
  const resp = await (await fetch("http://localhost:5117/api/players/get")).json();
  const list = document.querySelector("ul");
  resp.forEach(element => {
    const listItem = document.createElement("li");
    const name = document.createElement("p")
    name.innerHTML = element["name"]
    name.classList.add(`c${element["id"]}`)
    const surname = document.createElement("p");
    surname.innerHTML = element["surname"];
    surname.classList.add(`c${element["id"]}`)
    const sex = document.createElement("p");
    sex.innerHTML = genders[element["sex"]];
    sex.classList.add(`c${element["id"]}`)
    const birthDate = document.createElement("p")
    birthDate.innerHTML = element["birthDate"];
    birthDate.classList.add(`c${element["id"]}`)
    const team = document.createElement("p");
    team.innerHTML = element["teamName"];
    team.classList.add(`c${element["id"]}`)
    const country = document.createElement("p");
    country.innerHTML = countries[element["country"]];
    country.classList.add(`c${element["id"]}`)
    listItem.appendChild(name);
    listItem.appendChild(surname);
    listItem.appendChild(sex);
    listItem.appendChild(birthDate);
    listItem.appendChild(team);
    listItem.appendChild(country);
    listItem.innerHTML += `<button class="modal-button" value="${element["id"]}" onclick="GetModal(this)">
                              <img src="img/edit.png" alt="edit" width="30px">
                          </button>`
    list.appendChild(listItem);
  })
}


//Get players
loadPlayers();
//Get teams for form
loadTeams();
