const API_URL = "http://localhost:5187/api/Concert";

export async function getConcertSummaries(fetch: typeof window.fetch) {
    const res = await fetch(`${API_URL}`)
    return res.json();
}