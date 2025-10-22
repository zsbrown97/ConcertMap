const API_URL = "http://localhost:5187/api/Venue";

export async function getAllVenues(fetch: typeof window.fetch) {
    const res = await fetch(`${API_URL}`);
    return res.json();
}