// Inicializa tsParticles
tsParticles.load("particles-container", {
    particles: {
        number: { value: 100 },
        color: { value: "#00ff99" },
        shape: { type: "circle" },
        opacity: { value: 0.5 },
        size: { value: 3 },
        move: { enable: true, speed: 2, outModes: { default: "out" } },
        links: { enable: true, distance: 150, color: "#00ff99", opacity: 0.2, width: 1 }
    },
    interactivity: {
        events: { onhover: { enable: true, mode: "repulse" }, onclick: { enable: true, mode: "push" } }
    },
    detectRetina: true
});

// Animación de texto tipo código flotante
function createCodeParticles() {
    const container = document.getElementById('code-text-container');
    for (let i = 0; i < 30; i++) {
        const span = document.createElement('span');
        span.textContent = Math.random().toString(36).substring(2,8); // código aleatorio
        span.style.position = 'absolute';
        span.style.left = Math.random() * 100 + '%';
        span.style.top = Math.random() * 100 + '%';
        span.style.color = 'rgba(0,255,0,0.5)';
        span.style.fontFamily = 'monospace';
        span.style.fontSize = (12 + Math.random() * 20) + 'px';
        container.appendChild(span);

        anime({
            targets: span,
            translateY: [-100, 1000],
            duration: 8000 + Math.random()*5000,
            loop: true,
            easing: 'linear'
        });
    }
}
