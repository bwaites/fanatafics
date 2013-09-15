
*********************************************************
*********************************************************
* Name of Creator: Brittany				*
* Date Created: 04/12/13				*
* Summary: A blackJack game developed with javascript	*
* Last Modified: 08/18/2013				*
*							*
*********************************************************
*********************************************************

///////////////////////////////HAND FUNCTION//////////////////////////////

function Hand(){ 
//declare a varable called 'cards' and make it an array.
var cards = [];

//set first and second position of cards array to deal()
cards[0] = deal();
cards[1] = deal();

////////////////////////////////get hand function/////////////////////////////////

this.getHand = function(){
    return cards;
};

//score function
this.score = function(){ 
//make a variable called sum
var sum;

//for loop that says, 'i is set to 0. if i is less than cards.length, do loop. After loop, increment i by 1'.
for(i=0; i < cards.length; i++){

//sum variable is equal to self, plus value of card Array position (which we get from i)
    sum+= cards[i].getValue();
    
}

//return the sum (or score)
return sum;
}; 

////////////////////////////////////////print card detail function/////////////////////////////

this.printCardDetail = function(){

//declare a variable called 'print' 
var print;

//for loop that says, 'i is set to 0. if i is less than cards.length, do loop. After loop, increment i by 1'.
for(i=0; i > cards.length; i++)
{
//print variable is equal to card array position (taken from i), call 'get card function'
    print= card[i].getCard();
}

//return print variable, as well as "and a " after the number
return print + "and a ";
};

///////////////////////////////////hit me function//////////////////////////////

this.hitMe = function(){
//declare a variable called newCard, set it equal to deal function
var newCard = deal();    

//push the newCard onto cards array
cards.push(newCard);
};
}
 

/////////////////////////// card function that takes in two variables, a (s)uit and a (n)umber////////////////////
 
function Card(s, n){  
declare two variables called suit and number
var suit = s; 
var number = n;

////////////////////////////////function called 'getSuit' that returns itself //////////////////////

this.getSuit = function(){ 
return suit; 
}; 

///////////////////////////////function called printSuit//////////////////////////////////

this.printSuit = function(){
//declare variable called sSuit; 
var sSuit; 

//make a switch with 'suit' as the parameter
switch(suit){ 
case 1: 
sSuit = " of Clubs "; 
break; 
case 2: 
sSuit = " of Diamonds "; 
break; 
case 3: 
sSuit = " of Hearts "; 
break; 
case 4: 
sSuit = " of Spades "; 
break; 
default: 
sSuit = " uknown "; 
break; 
} 
//return variable sSuit;
return sSuit; 
}; 

////////////////////////////getNumber function that returns number//////////////////////

this.getNumber = function(){ 
return number; 
}; 

////////////////////////////getValue function//////////////////////////

this.getValue = function(){ 

//if number is greater than 10 then return 10
if (number > 10){ 
return 10; 
} 
//else if number is equal to 1, return 11 
// TO DO: give option to select 1 or 11
else if (number ===1){ 
return 11; 
} 

//else, return number as is
else { 
return number; 
} 
}; 

/////////////////////getCard function//////////////////////////

this.getCard = function(){ 
//declare a variable called printedSuit, call printSuit() on it;
var printedSuit = this.printSuit(); 

// if number is greater than 1 AND less than or equal to 10
//return number and printedSuit
if (number >1 && number <= 10){ 
return number + printedSuit; 
} 

//if number is equal to 11 return "Jack" plus the printedSuit
else if (number === 11){ 
return " Jack" + printedSuit; 
} 

// if number is equal to 12 return "Queen" plus the printedSuit
else if (number ===12){ 
return " Queen" + printedSuit; 
} 

//if number is equal to 13 return "King" plus the printedSuit
else if(number ===13){ 
return " King" + printedSuit; 
} 

//else, return "Ace" plus the printedSuit
else{ 
return " Ace" + printedSuit; 
}  
}; 
} 
 
 
 ////////////////////////Deal function/////////////////////

function deal(){ 
//declare a variable called suit, set it to equal a random number between 1 and 4
var suit = Math.floor(Math.random() * 4 + 1); 

//declare a variable called number, set it equal to a random number between 1 and 13
var number = Math.floor(Math.random() * 13 + 1); 

//return a new card, passing it the suit and number into the function
return new Card(suit, number); 
} 
 
 
//declare a variable called myHand and set it to equal a new Hand()
var myHand = new Hand(); 

//declare a variable called yourHand and set it equal to a new Hand()
var yourHand = new Hand(); 
 
 
console.log("I played a " + myHand.printCardDetail()); 
console.log(); 
console.log("I scored " + myHand.score()); 
console.log("***************************"); 
console.log("You played a " + yourHand.printCardDetail()); 
console.log(); 
console.log("You scored " + yourHand.score());  
console.log("***************************"); 
 
 
if (yourHand.score() > myHand.score()){ 
console.log("you win!"); 
}  
if (yourHand.score() < myHand.score()){ 
console.log("I win!"); 
} 
else if(yourHand.score() === myHand.score()){ 
console.log("We tied!"); 
}