import { html, page } from '../library.js';

let chooseMode = () => html`
<section>


<h1 class="title">Choose the game mode!</h1>
    

<div class="modesOptionsDiv">
<h2 class="secondaryText modeOption">Single Player</h2>
<h2 class="secondaryText modeOption">Multiplayer</h2>
</div>

    <div class="picturesForOptionsContainer">     
        <a>
          <img id="singleplayerImg" class="pictureOption" src="../../resources/singlePlayerOption.png">
        </a>

        <a>
          <img id="multiPlayerImg" class="pictureOption" src="../../resources/multiplayerOption.png">
        </a>
    </div>

</section>
`;
export async function showChooseMode(ctx) {
  ctx.render(chooseMode());

  let singleplayerImg = document.getElementById("singleplayerImg");
  singleplayerImg.addEventListener('click', (e) => {
    e.preventDefault();
    page.redirect("/settingGame");
  });

  let multiPlayerImg = document.getElementById("multiPlayerImg");
  multiPlayerImg.addEventListener('click', (e) => {
    e.preventDefault();
    page.redirect("/settingGame");
  });

}
