const protocol = window.location.protocol === "https:" ? "wss:" : "ws:";
const host = window.location.host;
const socket = new WebSocket(`${protocol}//${host}/AutoMaegler`);

socket.onopen = () => {
    console.log("WebSocket connected");
};

socket.onmessage = (event) => {
    console.log("Message from server:", event.data);
};

socket.onerror = (err) => {
    console.error("WebSocket error:", err);
};

socket.onclose = () => {
    console.log("WebSocket connection closed");
};
