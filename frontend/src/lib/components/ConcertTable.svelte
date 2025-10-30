<script lang="ts">
    import { onMount } from 'svelte'

    import * as Table from '$lib/components/ui/table/index.js';
</script>

<div class="
        border
        border-gray-300
        h-[40vh]
        rounded-2xl
        shadow-md
        w-full 
    "
>

    <Table.Root>
        <Table.Header>
            <Table.Row>
                <Table.Head>Date</Table.Head>
                <Table.Head>Band</Table.Head>
                <Table.Head>Venue</Table.Head>
            </Table.Row>
        </Table.Header>

        <Table.Body>
            <Table.Row>
                <Table.Cell>2010-08-22</Table.Cell>
                <Table.Cell>Rush</Table.Cell>
                <Table.Cell>Hollywood Casino Amphitheater</Table.Cell>
            </Table.Row>
            <Table.Row>
                <Table.Cell>2013-08-26</Table.Cell>
                <Table.Cell>Coheed and Cambria</Table.Cell>
                <Table.Cell>The Pageant</Table.Cell>
            </Table.Row>
        </Table.Body>
    </Table.Root>

</div>