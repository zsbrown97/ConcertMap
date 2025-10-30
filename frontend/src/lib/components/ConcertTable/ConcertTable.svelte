<script lang="ts">
    import { onMount } from 'svelte'
    import { getConcertSummaries } from '$lib/api/concerts';

    import * as Table from '$lib/components/ui/table/index.js';

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
    <Table.Root>
        <Table.Header class="bg-background sticky top-0 z-10">
            <Table.Row>
                <Table.Head>Date</Table.Head>
                <Table.Head>Band</Table.Head>
                <Table.Head>Venue</Table.Head>
            </Table.Row>
        </Table.Header>

        <Table.Body>
            {#each concertSummaries as c}
                <Table.Row>
                    <Table.Cell>{c.date}</Table.Cell>
                    <Table.Cell>{c.headliners}</Table.Cell>
                    <Table.Cell>{c.venueName}</Table.Cell>
                </Table.Row>
            {/each}
        </Table.Body>
    </Table.Root>
</div>