// Función global para Blazor
function createCodeParticles() {
    // Detectar modo oscuro
    const isDarkMode = document.body.classList.contains('dark-mode');

    // Color de las letras según el modo
    const blueColor = getComputedStyle(document.documentElement).getPropertyValue('--bootstrap-primary-button-dark-background').trim();

    const randomWords = ["xd", "jamon", "p0lent4", "wach0s", "arg", "Xdd", "asereje, g4rraF0vich, zzz, ;)"];

    // --- tsParticles ---
    tsParticles.load("particles-container", {
        particles: {
            number: { value: 80 },
            color: { value: blueColor },
            shape: { type: "circle" },
            opacity: { value: 0.4, random: true },
            size: { value: 3, random: true },
            move: { enable: true, speed: 2, outModes: { default: "out" } },
            links: { enable: true, distance: 120, color: blueColor, opacity: 0.2, width: 1 }
        },
        interactivity: {
            events: {
                onhover: { enable: true, mode: "repulse" },
                onclick: { enable: true, mode: "push" }
            }
        },
        detectRetina: true
    });

    // --- Anime.js: letras flotantes ---
    const container = document.getElementById('code-text-container');
    container.innerHTML = ''; // limpiar contenido previo

    const totalLetters = 40;
    const animationDuration = 8000;
    const staggerDelay = 200;

    for (let i = 0; i < totalLetters; i++) {
        setTimeout(() => {
            const span = document.createElement('span');
            span.textContent = Math.random().toString(36).substring(2, 3);
            span.style.position = 'absolute';
            span.style.left = Math.random() * 100 + '%';
            span.style.top = Math.random() * 100 + '%';
            span.style.color = blueColor;
            span.style.fontFamily = 'monospace';
            span.style.fontSize = (14 + Math.random() * 24) + 'px';
            span.style.userSelect = 'none';
            container.appendChild(span);

            anime({
                targets: span,
                translateY: [-100, 1000],
                duration: animationDuration + Math.random() * 5000,
                loop: true,
                easing: 'linear'
            });

            // Reemplazo de letra por palabra al azar con menor frecuencia
            setInterval(() => {
                if (Math.random() < 0.02) { // 2% de chance cada intervalo
                    const randomWord = randomWords[Math.floor(Math.random() * randomWords.length)];
                    span.textContent = randomWord;
                }
            }, 8000 + Math.random() * 5000); // intervalo cada 8-13 segundos aprox
        }, i * staggerDelay); // crea cada letra con un pequeño retraso
    }
}
