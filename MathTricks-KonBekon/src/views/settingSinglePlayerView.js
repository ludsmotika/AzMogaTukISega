import { html, page } from '../library.js';

const settingGameView = () => html`
<section>
<div class="main-container">
<h1 class="title">Setting the game</h1>
<form id="settingGameForm">
    
    <label class="secondaryText" for="playerOneName">Name:</label>
    <input class="inputStyle" type="text" name="playerOneName" required>

    <label class="secondaryText" for="nDimension">Columns count:</label>
    <input class="inputStyle" type="number" name="nDimension" min="4" max="10" required>
    <label class="secondaryText" for="mDimension">Rows count:</label>
    <input class="inputStyle" type="number" name="mDimension" min="4" max="10" required>

    <input type="submit" class="gameButton" value="Play">
  </form>
  </section>
`;


export async function showSettingSinglePlayer(ctx) {
    ctx.render(settingGameView());

    let settingGameForm = document.getElementById("settingGameForm");
    settingGameForm.addEventListener('submit', startTheGame);

    async function startTheGame(event) {
        event.preventDefault();

        let form = event.target;
        const formData = new FormData(form)
        const formObject = {};

        for (let [key, value] of formData.entries()) {
            formObject[key] = value;
        }

        formObject['playerTurn']="playerOne";
        formObject['playerTwoName']="Mr. Robot";
        
        localStorage.setItem('gameData', JSON.stringify(formObject));
        page.redirect('/singlePlayer');
        //validation

    }
}







