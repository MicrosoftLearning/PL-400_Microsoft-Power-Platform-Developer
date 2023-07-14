import { IInputs, IOutputs } from "./generated/ManifestTypes";
import DataSetInterfaces = ComponentFramework.PropertyHelper.DataSetApi;
type DataSet = ComponentFramework.PropertyTypes.DataSet;

class TimelineData {
    id: string;
    content: string;
    start: string;
    className: string;

    constructor(id: string, content: string, start: string, className: string) {
        this.id = id;
        this.content = content;
        this.start = start;
        this.className = className;
    }
}

const vis = require('vis-timeline');

export class timelinecontrol implements ComponentFramework.StandardControl<IInputs, IOutputs> {

    private _timelineElm: HTMLDivElement;
    private _timelineVis: any;
    private _timelineData: TimelineData[] = [];

    /**
     * Empty constructor.
     */
    constructor() {

    }

    /**
     * Used to initialize the control instance. Controls can kick off remote server calls and other initialization actions here.
     * Data-set values are not initialized here, use updateView.
     * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to property names defined in the manifest, as well as utility functions.
     * @param notifyOutputChanged A callback method to alert the framework that the control has new outputs ready to be retrieved asynchronously.
     * @param state A piece of data that persists in one session for a single user. Can be set at any point in a controls life cycle by calling 'setControlState' in the Mode interface.
     * @param container If a control is marked control-type='standard', it will receive an empty div element within which it can render its content.
     */
    public init(context: ComponentFramework.Context<IInputs>, notifyOutputChanged: () => void, state: ComponentFramework.Dictionary, container: HTMLDivElement): void {
        this._timelineElm = document.createElement("div");

        container.appendChild(this._timelineElm);
    }


    /**
     * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
     * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
     */
    public updateView(context: ComponentFramework.Context<IInputs>): void {
        if (!context.parameters.timelineDataSet.loading) {
            // Get sorted columns on View
            this.createTimelineData(context.parameters.timelineDataSet);
            this.renderTimeline();
        }
    }

    /**
     * It is called by the framework prior to a control receiving new data.
     * @returns an object based on nomenclature defined in manifest, expecting object[s] for property marked as “bound” or “output”
     */
    public getOutputs(): IOutputs {
        return {};
    }

    /**
     * Called when the control is to be removed from the DOM tree. Controls should use this call for cleanup.
     * i.e. cancelling any pending remote calls, removing listeners, etc.
     */
    public destroy(): void {
        // Add code to cleanup control if necessary
    }

    private renderTimeline(): void {
        // Create a DataSet (allows two way data-binding)
        var items = this._timelineData;
        // Configuration for the Timeline
        var options = {};
        // Create a Timeline
        var timeline = new vis.Timeline(this._timelineElm, items, options);
    }

    private createTimelineData(gridParam: DataSet) {
        this._timelineData = [];
        if (gridParam.sortedRecordIds.length > 0) {
            for (let currentRecordId of gridParam.sortedRecordIds) {

                console.log('record: ' + gridParam.records[currentRecordId].getRecordId());

                var permitName = gridParam.records[currentRecordId].getFormattedValue('contoso_name')
                var permitDate = gridParam.records[currentRecordId].getFormattedValue('contoso_scheduleddate')
                var permitStatus = gridParam.records[currentRecordId].getFormattedValue('statuscode')
                var permitColor = "green";
                if (permitStatus == "Failed")
                    permitColor = "red";
                else if (permitStatus == "Canceled")
                    permitColor = "yellow";

                console.log('name:' + permitName + ' date:' + permitDate);

                if (permitName != null)
                    this._timelineData.push(new TimelineData(currentRecordId, permitName, permitDate, permitColor));
            }
        }
        else {
            //handle no data
        }
    }
}
