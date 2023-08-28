// <script>
//     async function fetchQuotes() {
//     try {
//     const response = await fetch('/api/quotes');
//     if (!response.ok) {
//     throw new Error(`HTTP error! Status: ${response.status}`);
// }
//     const quotes = await response.json();
//     const quotesList = document.getElementById('quotes-list');
//
//     quotes.forEach(quote => {
//     const quoteItem = document.createElement('li');
//     quoteItem.innerHTML = `<strong>${quote.Author}:</strong> ${quote.QuoteText}`;
//     quotesList.appendChild(quoteItem);
// });
// } catch (error) {
//     console.error('Error fetching quotes:', error);
// }
// }
//
//     fetchQuotes();
// </script>

// function showContainer(containerId) {
//     let containers = document.getElementsByClassName("card");
//     for (let container of containers) {
//         container.style.display = "none";
//     }
//     document.getElementById(containerId).style.display = "block";
// }

function showContainer(containerId) {
    const containers = document.querySelectorAll('.card');
    containers.forEach(container => {
        container.style.display = 'none';
    });
    document.getElementById(containerId).style.display = 'block';
}

class Quote {
    constructor(id, quoteText, author, isFavorite) {
        this.id = id;
        this.quoteText = quoteText;
        this.author = author
        this.isFavorite = isFavorite;
    }
}

let quotes = [];

document.getElementById("getAllBtn").addEventListener("click", async () => {
    try {
        const response = await fetch("/api/quotes");
        const quotesList = await response.json();
        
        quotes = quotesList.map(item => new Quote(item.id, item.quoteText, item.author, item.isFavorite))
        const quotesListElement = document.getElementById('quotes-list');
        quotesListElement.innerHTML = '';

        quotes.forEach(quote => {
            const listItem = document.createElement('li');
            listItem.innerHTML = `
                <p style="margin: 15px 0 5px 0">${quote.quoteText}</p>
                <div>
                    <div style="display: flex; width: 100%">—<a style="margin-right: 5%; margin-left: 5px">${quote.author}</a><i class="heart-icon ${quote.isFavorite ? 'fa-solid' : 'fa-regular'} fa-heart" style="color: #ff0000; align-self: center;""></i></div>
                </div>`;
            
            quotesListElement.appendChild(listItem);

            const heartIcon = listItem.querySelector('.heart-icon');
            
            heartIcon.addEventListener('click', () => {
                quote.isFavorite = !quote.isFavorite;
                heartIcon.classList.toggle('fa-solid');
                heartIcon.classList.toggle('fa-regular');
            });
        });
        
        showContainer('getAllContainer');
    } catch (error) {
        console.error("Error fetching data:", error);
    }
});




// async function fetchAllQuotes() {
//    
//
//     const quotesList = document.getElementById('quotes-list');
//     quotesList.innerHTML = ''; // Clear existing list
//
//     allQuotes.forEach(quote => {
//         const listItem = document.createElement('li');
//         listItem.innerHTML = `
//                     <p>${quote.QuoteText}</p>
//                     <p>— <span>${quote.Author}</span>${quote.IsFavorite ? '❤️' : '🤍'}</p>
//                 `;
//         quotesList.appendChild(listItem);
//     });
// }