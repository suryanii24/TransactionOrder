document.getElementById('productForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const productName = document.getElementById('productName').value;
    const productDescription = document.getElementById('productDescription').value;
    const productPrice = document.getElementById('productPrice').value;

    const productData = {
        name: productName,
        description: productDescription,
        price: parseFloat(productPrice)
    };

    fetch('/api/products', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(productData),
    })
        .then(response => response.json())
        .then(data => {
            console.log('Product added:', data);
            // Handle success response
        })
        .catch((error) => {
            console.error('Error:', error);
            // Handle error
        });
});
