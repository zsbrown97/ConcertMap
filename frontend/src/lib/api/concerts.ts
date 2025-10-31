import { PUBLIC_API_URL } from "$env/static/public";

export async function getConcertSummaries(fetch: typeof window.fetch) {
    const res = await fetch(`${PUBLIC_API_URL}/Concert`)
    return res.json();
}