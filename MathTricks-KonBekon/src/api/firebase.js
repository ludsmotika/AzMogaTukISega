
const firebaseConfig = {
    apiKey: "AIzaSyC8ihU8oXvFx85Yt8eoM9ZYEiWlXoa2juQ",
    authDomain: "az-moga-tuk-i-sega-e929e.firebaseapp.com",
    databaseURL: "https://az-moga-tuk-i-sega-e929e-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "az-moga-tuk-i-sega-e929e",
    storageBucket: "az-moga-tuk-i-sega-e929e.appspot.com",
    messagingSenderId: "480810352077",
    appId: "1:480810352077:web:82dea1f8e47a1691f11884"
};


// Initialize Firebase

firebase.initializeApp(firebaseConfig);
var database = firebase.database();
const dataRefMultiplayer = database.ref("/Scores/Multiplayer");
const dataRefSinglePlayer = database.ref("/Scores/SinglePlayer");


//functions to read and write data into the real-time database

//multiplayer

export async function addLastGame(playerOneName, playerTwoName, playerOneScore, playerTwoScore) {

    //remove the oldest game

    await dataRefMultiplayer.once("value", async (snapshot) => {
        // The data snapshot contains the retrieved data
        const data = snapshot.val();
        const scoresArray = [...Object.entries(data)];

        await dataRefMultiplayer.child(scoresArray[0][0]).remove();
    });

    //add the last one
    var gameData = {
        playerOneName,
        playerTwoName,
        playerOneScore,
        playerTwoScore
    }

    const newDataRef = dataRefMultiplayer.push();
    newDataRef.set(gameData);
}

export async function getLastMultiplayerGamesData() {

    let lastGames = new Object();

    await dataRefMultiplayer.once("value", async (snapshot) => {
        // The data snapshot contains the retrieved data
        const data = await snapshot.val();
        const scoresArray = [...Object.entries(data)];

        lastGames = scoresArray;
    });

    return lastGames;

}


//singlePlayer

//methods for adding best scores while playing versus the bot
//check if it is in the top 10 scores and if it is add it to the best scores
//save only the player name and his score

export async function getTopScores() {

    let bestScores = new Object();

    await dataRefSinglePlayer.once("value", async (snapshot) => {
        // The data snapshot contains the retrieved data
        const data = await snapshot.val();
        const scoresArray = [...Object.entries(data)];

        bestScores = scoresArray;
    });

    return bestScores;
}


export async function checkForNewBestScore(score) {
    let scores = await getTopScores();
    //const scoresArray = [...Object.entries(scores)];
    let index = scores.findIndex(x => x[1].score < score);
    if (index != -1) {
        //we found new best score
        return true;
    }
    return false;
}


export async function setNewBestRecord(username, score) {

    //check if this score has to be added
    let toAdd = await checkForNewBestScore(score);

    if(toAdd==false){
        return;
    }

    //if true remove the worst score from the table
    let scores = await getTopScores();

    let worstScoreIndex = -1;
    let worstScore = Number.MAX_SAFE_INTEGER;
    let index=0;
    for (const score of scores) {
        if (score[1].score <= worstScore) {
            worstScore = score[1].score;
            worstScoreIndex=index;
        }
        index++;
    }

    database.ref(`/Scores/SinglePlayer/${scores[worstScoreIndex][0]}`).remove();


    //add the new one 


    //logic for removing the worst score

    //choose from which category you have to get the best score
    //let scores = await getTopScores();
    //const scoresArray = [...Object.entries(scores)];

    //database.ref(`/Scores//${scoresArray[indexOfMinScore][0]}`).remove();


    //setting the new best score by category

    var data = {
        username,
        score
    }

    var newData = dataRefSinglePlayer.push();
    newData.set(data);
}
