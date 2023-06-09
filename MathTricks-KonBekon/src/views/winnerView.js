import { html } from '../library.js'

const winnerView = (winner, points) => html`
<section>

<div id="confetti-container"></div>

<p class="title winnersPageTitle">The winner is ${winner} with a score of: ${points}</p>


<a href="/chooseMode">
<button class="gameButton winnersPageButton" id="game">
    <span></span>
    <span></span>
    <span></span>
    <span></span>
    Play Again
</button>
</a>
<a href="/">
<button class="gameButton winnersPageButton" id="game">
    <span></span>
    <span></span>
    <span></span>
    <span></span>
   Main page
</button>
</a>
</section>`;

export async function showWinner(ctx) {

    let bestScore = JSON.parse(localStorage.getItem('bestScore'));
    let winnerName = localStorage.playerWinner;
    
    localStorage.clear();
    ctx.render(winnerView(winnerName, bestScore));

}