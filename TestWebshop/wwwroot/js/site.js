// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', () => {
    const addToCartButtons = document.querySelectorAll('.add-to-cart');

    addToCartButtons.forEach(button => {
        button.addEventListener('click', (e) => {
            const movieTitle = e.target.parentElement.querySelector('h3').textContent;
            alert(`Added "${movieTitle}" to cart!`);
            // Implement further cart functionality as needed
        });
    });
});
