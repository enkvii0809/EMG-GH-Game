%% By Simon Avrillon, 2023

function [datadiff, mask] = getSIGdiff(data,xy, EMGmask)

data = bandpassingals(data,2048,1);

for i = 1:size(data,1)
    SIG{xy(i,1),xy(i,2)} = data(i,:);
    masktmp(xy(i,1),xy(i,2)) = EMGmask(i);
end

ch = 1;
for r = 1:size(SIG,1)-1
    for c = 1:size(SIG,2)
        if ~isempty(SIG{r,c}) && ~isempty(SIG{r+1,c})
            datadiff(ch,:) = SIG{r,c} - SIG{r+1,c};
            mask(ch) = masktmp(r,c) + masktmp(r+1,c);
            ch = ch+1;
        end
    end
end

end
