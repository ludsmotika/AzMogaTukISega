import { html } from '../library.js';
import { getLastMultiplayerGamesData, getTopScores } from '../api/firebase.js';


let statsView = (bestScoresSinglePlayer, lastMultiplayerGames, generateSinglePlayerTable, generateMultiplayerTable) => html`
<section>
       <div class="headingContainerStatsPage"> 
           <a href="/" class="returnAnchorStatsPage">
               <button class="gameButton buttonSettingsPage" id="game">
                <span></span>
                <span></span>
                <span></span>
                <span></span>
                Return
               </button>
           </a>
           
           <p class="title statsPageTitle"> Game Stats </p>
        </div>
    
  
    <div class="statsContainer">
         <table class="statsTable">
         <caption class="secondaryText">Single Player Best Scores</caption>
               <thead>
                 <tr>
                    <th>Place</th>
                    <th>Name</th>
                    <th>Score</th>
                 </tr>
               </thead>
               ${generateSinglePlayerTable(bestScoresSinglePlayer)}
         </table >
         <table class="statsTable">
         <caption class="secondaryText">Last Multiplayer Games</caption>
               <thead>
                 <tr>
                    <th>Player One</th>
                    <th>Player One Score</th>
                    <th>Player Two</th>
                    <th>Player Two Score</th>
                 </tr>
               </thead>
               ${generateMultiplayerTable(lastMultiplayerGames)}
         </table >
    </div >

</section >
    `;
export async function showStatsView(ctx) {

    //get the data from firebase

    let lastMultiplayerGames = await getLastMultiplayerGamesData();
    let bestScoresSinglePlayer = await getTopScores();

    //pass it to the view and render it
    ctx.render(statsView(bestScoresSinglePlayer, lastMultiplayerGames, generateSinglePlayerTable, generateMultiplayerTable));

    function generateSinglePlayerTable(bestScoresSinglePlayer) {

        //sort the scores from the best to the worst
        bestScoresSinglePlayer.sort((a, b) => b[1].score - a[1].score);

        let tBody = document.createElement('tbody');

        let place = 1;
        for (const element of bestScoresSinglePlayer) {
            let tr = document.createElement('tr');
            let tdPlace = document.createElement('td');
            tdPlace.textContent = place++;
            tr.appendChild(tdPlace);
            let tdName = document.createElement('td');
            tdName.textContent = element[1].username;
            tr.appendChild(tdName);
            let tdScore = document.createElement('td');
            tdScore.textContent = element[1].score;
            tr.appendChild(tdScore);
            tBody.appendChild(tr);
        }

        return tBody;
    }

    function generateMultiplayerTable(lastMultiplayerGames) {

        let tBody = document.createElement('tbody');
        lastMultiplayerGames.forEach(element => {
            let tr = document.createElement('tr');

            Object.entries(element[1]).forEach(([key, value]) => {
                let td = document.createElement('td');
                td.textContent = value;
                tr.appendChild(td);
            })

            tBody.appendChild(tr);
        });

        return tBody;
    }
}
