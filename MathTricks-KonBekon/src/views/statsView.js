import { html } from '../library.js';
import { getLastMultiplayerGamesData } from '../api/firebase.js';


let statsView = (lastMultiplayerGames, generateMultiplayerTable) => html`
<section>

    <p class="title statsPageTitle"> Game Stats </p>
  
    <div class="statsContainer">
         <table class="statsTable">
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
         <table class="statsTable">
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

    //pass it to the view and render it
    ctx.render(statsView(lastMultiplayerGames, generateMultiplayerTable));


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
