import { getAllVenues } from "$lib/api/venues";

export async function load({ fetch }) {
    const venues = await getAllVenues(fetch);

    return {venues}
}