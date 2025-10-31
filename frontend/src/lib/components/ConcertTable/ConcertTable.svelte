<script lang="ts">
    import { onMount } from 'svelte'
    import { getConcertSummaries } from '$lib/api/concerts';

    let concertSummaries = []

    onMount(async () => {
        const [concertData] = await Promise.all([getConcertSummaries(fetch)]);

        concertSummaries = concertData;
    });
</script>

<div class="
    border
    border-gray-300
    h-[40vh]
    overflow-auto
    rounded-2xl
    shadow-md
    w-full 
">

    <div class="h-full overflow-auto">
        <table class="border-collapse min-w-full" >
            <thead class="bg-white sticky top-0 z-10">
                <tr>
                    <th class="text-left px-4 py-2">Date</th>
                    <th class="text-left px-4 py-2">Band</th>
                    <th class="text-left px-4 py-2">Venue</th>
                </tr>
            </thead>
            <tbody>
                {#each concertSummaries as c}
                    <tr class="border-t">
                        <td class="px-4 py-2">{c.date}</td>
                        <td class="px-4 py-2">{c.headliners}</td>
                        <td class="px-4 py-2">{c.venueName}</td>
                    </tr>
                {/each}
            </tbody>
        </table>
    </div>
</div>