// Función global para Blazor
function createCodeParticles() {
    // Detectar modo oscuro
    const isDarkMode = document.body.classList.contains('dark-mode');

    // Color de las letras según el modo
    const textColor = isDarkMode ? 'rgba(13,110,253,0.7)' : 'rgba(0,255,0,0.7)'; // azul o verde Matrix

    // --- tsParticles ---
    tsParticles.load("particles-container", {
        particles: {
            number: { value: 80 },
            color: { value: textColor },
            shape: { type: "circle" },
            opacity: { value: 0.4, random: true },
            size: { value: 3, random: true },
            move: { enable: true, speed: 2, outModes: { default: "out" } },
            links: { enable: true, distance: 120, color: textColor, opacity: 0.2, width: 1 }
        },
        interactivity: {
            events: {
                onhover: { enable: true, mode: "repulse" },
                onclick: { enable: true, mode: "push" }
            }
        },
        detectRetina: true
    });

    // --- Anime.js: letras flotantes tipo Matrix ---
    const container = document.getElementById('code-text-container');

    // Limpiar contenido previo
    container.innerHTML = '';

    for (let i = 0; i < 40; i++) {
        const span = document.createElement('span');
        span.textContent = Math.random().toString(36).substring(2, 3); // letra aleatoria
        span.style.position = 'absolute';
        span.style.left = Math.random() * 100 + '%';
        span.style.top = Math.random() * 100 + '%';
        span.style.color = textColor;
        span.style.fontFamily = 'monospace';
        span.style.fontSize = (14 + Math.random() * 24) + 'px';
        span.style.userSelect = 'none';
        container.appendChild(span);

        anime({
            targets: span,
            translateY: [-100, 1000],
            duration: 8000 + Math.random() * 5000,
            loop: true,
            easing: 'linear'
        });
    }
}
