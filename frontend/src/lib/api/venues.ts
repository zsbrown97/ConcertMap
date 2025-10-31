import { PUBLIC_API_URL } from "$env/static/public";
export async function getAllVenues(fetch: typeof window.fetch) {
    const res = await fetch(`${PUBLIC_API_URL}/Venue`);
    return res.json();
}
