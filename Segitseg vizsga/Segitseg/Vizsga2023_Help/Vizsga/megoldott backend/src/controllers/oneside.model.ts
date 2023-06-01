import { Schema, model } from "mongoose";

const onesideSchema = new Schema(
    {
        _id: Number,
        nev: {
            type: String,
            required: true,
            unique: true,
        },
    },

    { versionKey: false, id: false, toJSON: { virtuals: true }, toObject: { virtuals: true } },
);

onesideSchema.virtual("virtualPop", {
    ref: "nside",
    localField: "_id",
    foreignField: "kategoria", // ref_Field
    justOne: false,
});

const onesideModel = model("oneside", onesideSchema, "kategoriak");

export default onesideModel;
